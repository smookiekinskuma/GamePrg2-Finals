using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;

public class Cultist : MonoBehaviour
{ 
    //Reset

    [Header("Scripts")]
    public Player player;
    public Gameplay gameplay;
    public CultHeart cultheart;
    public AIPath aiPath;

    [Header("Cult Body")]//Cultist Moving
    public Rigidbody2D rigidBody;
    public Animator anim;

    [Header("BulletDrop")]//Bullet Drop
    public Transform bulletPlace;
    public GameObject bulletDropPrefab;

    [Header("Heart")]//Health
    public int Health;
    public int Batch;
    public bool alive, attack;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attack = false;
        Health = 5;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Health == 0) //If the cultist is dead
        {
            Batch++;
            switch (Batch)
            {
                case 1:
                    Batch1(); break;
                case 2:
                    Batch2(); break;
                case 3:
                    Batch3(); break;
                case 4:
                    Batch4(); break;
                case 5:
                    Batch5(); break;
                case 6:
                    Batch6(); break;
                case 7:
                    Batch7(); break;
                case 8:
                    Batch8(); break;
                case 9:
                    Batch9(); break;
                case 10:
                    Batch10(); break;
                case 11:
                    Batch11(); break;
                case 12:
                    Batch12(); break;
                case 13:
                    Batch13(); break;
                case 14:
                    Batch14(); break;
            }
            aiPath.maxSpeed = 0; 
        }

        if (attack == true && player.Health >= 1) //If the cultist attacks
        { player.Health--; attack = false; }

        if (aiPath.desiredVelocity.x >= 0.01f) //Flip
        { transform.localScale = new Vector3(-1f, 1f, 1f); } 
        else if (aiPath.desiredVelocity.x <= -0.01f)
        { transform.localScale = new Vector3(1f, 1f, 1f); }
    }

    public void Dead()
    { cultheart.Kill++; } //Kill count. Jk it's for the waves.

    public void ReallyDead()
    {
        Health = 0;
    }

    //Attack and Hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Les")) //Attacking Les
        {   if (Health > 0)
            { anim.GetComponent<Animator>().Play("Cultist_AttackL"); }
        }

        if (collision.CompareTag("Bullet")) //Getting hit
        {
            Health--;
            Instantiate(bulletDropPrefab, bulletPlace.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }

    //Attack
    public void Attack()
    { attack = true; }

    //For the animation. Clueless.
    public void Batch1()
    {
        foreach(GameObject member in cultheart.Batch1)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch2()
    {
        foreach (GameObject member in cultheart.Batch2)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch3()
    {
        foreach (GameObject member in cultheart.Batch3)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch4()
    {
        foreach (GameObject member in cultheart.Batch4)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch5()
    {
        foreach (GameObject member in cultheart.Batch5)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch6()
    {
        foreach (GameObject member in cultheart.Batch6)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch7()
    {
        foreach (GameObject member in cultheart.Batch7)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch8()
    {
        foreach (GameObject member in cultheart.Batch8)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch9()
    {
        foreach (GameObject member in cultheart.Batch9)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch10()
    {
        foreach (GameObject member in cultheart.Batch10)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch11()
    {
        foreach (GameObject member in cultheart.Batch11)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch12()
    {
        foreach (GameObject member in cultheart.Batch12)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch13()
    {
        foreach (GameObject member in cultheart.Batch13)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
    public void Batch14()
    {
        foreach (GameObject member in cultheart.Batch14)
        { member.GetComponent<Animator>().Play("Cultist_Dead"); }
    }
}
