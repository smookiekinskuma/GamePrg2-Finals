using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using static Unity.Collections.AllocatorManager;

public class Player : MonoBehaviour
{
    [Header("Script")]
    public Gameplay gameplay;
    public CultHeart cultheart;
    public Acts acts;


    [Header("Moving")]//Les Moving
    public float moveSpeed;
    public float inputHorizontal;
    public float inputVertical;
    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    public bool right = true; //For inverting the character
    public GameObject BulletSpawn;

    [Header("Storage")]//Les' Storage
    public int Health, BulletCap;

    [Header("Shooting")]//Shooting
    public Transform shootingPointR;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    { 
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Default
        moveSpeed = 3;
        BulletCap = 4;
        Health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting(); // go bang bang bang
        Movement();
        HealthBar();
        Cheats();
    }

    void FixedUpdate()
    {
        rigidBody.velocity = movementInput * moveSpeed;
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        //To flip
        if(inputHorizontal != 0)
        { rigidBody.AddForce(new Vector2(inputHorizontal * moveSpeed, 0f)); }
        if (inputHorizontal > 0 && !right) { Flip(); }
        if (inputHorizontal < 0 && right) { Flip(); }
    }
    private void OnMove(InputValue inputValue)
    { movementInput = inputValue.Get<Vector2>(); }
    private void Movement()
    {
        //Movement Animation
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

        //Shift
        if (Input.GetKey(KeyCode.LeftShift))
        { 
            moveSpeed = 5;
            if (gameplay.TutorialNo == 1) { gameplay.TutorialNo = 2; } 
        } else { moveSpeed = 3; }
    }

    void Flip()
    {
        //Player
        transform.Rotate(0f, 180f, 0f);
        right = !right;
    } 

    //Shooting
    private void Shooting()
    {
        if (BulletCap == 5)
        { gameplay.BulletStatus_Update = "FULL"; }

        if (BulletCap < 5 && BulletCap > 0)
        { gameplay.BulletStatus_Update = ""; }

        if (BulletCap == 0)
        { gameplay.BulletStatus_Update = "EMPTY"; }
        //Bang bang bang
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (BulletCap > 0 && Health != 0)
            {
                BulletCap--;
                anim.GetComponent<Animator>().Play("Les_ShootR");
                Instantiate(bulletPrefab, shootingPointR.position, transform.rotation);
            }
        }
    }

    //Health
    private void HealthBar()
    {
        if (Health >= 6)
        { gameplay.HealthStatus_Update = "Great"; }
        if (Health <= 5)
        {
            gameplay.LesThoughts_Update = "I feel weak... I should be more careful...";
            gameplay.HealthStatus_Update = "Weak";
            gameplay.RedShadow.DOFade(0.30f, gameplay.FadeTimer);
        } else { gameplay.RedShadow.DOFade(0f, gameplay.FadeTimer); }

        if (Health == 0)
        {
            moveSpeed = 0;
            gameplay.LesThoughts_Update = "I can't go any longer...";
            gameplay.HealthStatus_Update = "Dead";
            anim.GetComponent<Animator>().Play("Les_DeadR");

            //Animation
            Sequence GameOver_ = DOTween.Sequence();
            GameOver_.Append(gameplay.RedShadow.DOFade(1f, 0.5f));
            GameOver_.Append(gameplay.BlackShadow.DOFade(1f, 1f)).SetDelay(0.5f).onComplete = GameOverShadow; 
        }       
    }
    //End of Health

    //GameOver
    public void GameOverShadow()
    {
        Sequence GameOver_ = DOTween.Sequence();
        GameOver_.Append(gameplay.GameOverBlack.DOFade(0f, 0.5f)).onComplete = ActiveGameOver;
        gameplay.gameoverFolder.SetActive(true); 
    }
    public void ActiveGameOver()
    {
        gameplay.GameOverBlackGO.SetActive(false);
    }
    //End of GameOver

    //Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Reloading
        if (collision.CompareTag("BulletDrop"))
        {
            if (BulletCap < 5) { BulletCap++; Destroy(collision.gameObject); }
            if (gameplay.TutorialNo == 2) { gameplay.TutorialNo = 3; }
        }
        
        //The Hallway
        if (collision.CompareTag("TooLong"))
        { if (gameplay.TutorialNo == 0) { gameplay.TutorialNo = 1; } gameplay.TooLong.SetActive(false); }

        if (collision.CompareTag("Respawn"))//Respawn first batch of cultists
        { if (gameplay.TutorialNo == 3) { gameplay.TutorialNo = 4; } cultheart.CultistTutorial.SetActive(false); }

        if (collision.CompareTag("OneLastTutorial"))//Reminder about the health bar
        { if (gameplay.TutorialNo == 5) { gameplay.TutorialNo = 6; } gameplay.OneLastTutorial.SetActive(false); }

        if (collision.CompareTag("Library"))//To The Library
        {
            if (gameplay.TutorialNo == 6) { gameplay.TutorialNo = 7; } 
            gameplay.ToLibrary.SetActive(false);
            gameplay.Library(); 
        }
        //End of Hallway

        //The Library
        if (collision.CompareTag("CultistLibrary"))
        {
            gameplay.TutorialNo = 8;
            cultheart.Batch_2.SetActive(true); 
            cultheart.CultistLibrary.SetActive(false); 
        }

        if (collision.CompareTag("Classroom"))
        {
            Health = 10;
            acts.SceneProgression++;
            gameplay.ToClassroom.SetActive(false); 
        }
        //End of Library

        //The Classroom
        if (collision.CompareTag("CultistClassroom"))
        {
            cultheart.Batch_5.SetActive(true);
            cultheart.CultistClassroom.SetActive(false); 
        }

        if (collision.CompareTag("Chapel"))
        {
            Health = 10;
            gameplay.Chapel();
            gameplay.ToChapel.SetActive(false); 
        }
        //End of Classroom

        //The Chapel
        if (collision.CompareTag("CultistChapel"))
        {
            cultheart.Batch_8.SetActive(true);
            cultheart.CultistChapel.SetActive(false); 
        }

        if (collision.CompareTag("Basement"))
        {
            Health = 10;
            acts.SceneProgression++;
            gameplay.ToBasement.SetActive(false); 
        }
        //End of Chapel

        //The Basement
        if (collision.CompareTag("CultistBasement"))
        {
            cultheart.Batch_11.SetActive(true);
            cultheart.CultistBasement.SetActive(false); 
        }

        if (collision.CompareTag("TheEnd"))
        {
            acts.SceneProgression++;
            acts.ChapterProgression = 5;
            gameplay.TheEnd.SetActive(false); 
        }
        //End of Basement
    }
    //End of Collision

    private void Cheats()
    {
        //HealthCheck
        if (Input.GetKeyDown(KeyCode.P))//KILL
        { if (Health > 0) { Health--; } }

        if (Input.GetKeyDown(KeyCode.O))//Live
        { if (Health <= 10) { Health++; } }

        //Moar Bullets
        if (Input.GetKeyDown(KeyCode.I))
        { if (BulletCap < 5) { BulletCap++; } }
    }
}
