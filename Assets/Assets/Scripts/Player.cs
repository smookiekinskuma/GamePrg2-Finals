using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Gameplay gameplay;

    //Les Moving
    public float moveSpeed, inputHorizontal, inputVertical;
    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;
    public bool right = true; //Movement Conditions

    //Les' Storage
    public int Health, BulletCap;

    //Shooting
    public Transform shootingPointR, shootingPointL;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //Default
        moveSpeed = 4;
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

        //To slip
        if(inputHorizontal != 0)
        {
            rigidBody.AddForce(new Vector2(inputHorizontal * moveSpeed, 0f));
        }
        if (inputHorizontal > 0 && !right) { Flip(); }
        if (inputHorizontal < 0 && right) { Flip(); }
    }
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
    private void Movement()
    {
        //Movement Animation
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

        //For the tutorial
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        { if (gameplay.TutorialNo == 0) { gameplay.TutorialNo = 1; } }

        //Shift
        if (Input.GetKey(KeyCode.LeftShift))
        { 
            moveSpeed = 7; 
            if (gameplay.TutorialNo == 1) { gameplay.TutorialNo = 2; } 
        } else { moveSpeed = 4; }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        right = !right;
    } 

    //Shooting
    private void Shooting()
    {
        //Bang bang bang
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (BulletCap > 0)
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
        if (Health == 0)
        {
            moveSpeed = 0;
            anim.GetComponent<Animator>().Play("Les_DeadR");
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Reloading
        if (collision.CompareTag("Bullet"))
        {
            if (BulletCap < 5) { BulletCap++; Destroy(collision.gameObject); }
            if (gameplay.TutorialNo == 2) { gameplay.TutorialNo = 3; }
        }

        //Respawn first batch of cultists
        if (collision.CompareTag("Respawn"))
        {
            if (gameplay.TutorialNo == 3) { gameplay.TutorialNo = 4; }
        }

        //Reminder about the health bar
        if (collision.CompareTag("OneLastTutorial"))
        {
            if (gameplay.TutorialNo == 5) { gameplay.TutorialNo = 6; }
        }
    }

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
