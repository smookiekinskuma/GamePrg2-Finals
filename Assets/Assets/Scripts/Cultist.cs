using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : MonoBehaviour
{
    //Reset

    public Player player;
    public Gameplay gameplay;

    //Cultist Moving
    public Rigidbody2D rigidBody;
    public Animator anim;

    public Transform bulletPlace;
    public GameObject bulletDropPrefab;

    //Health
    public int Health, Death;
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
        { anim.GetComponent<Animator>().Play("Cultist_Dead"); }

        if (attack == true) //If the cultist attacks
        { player.Health--; attack = false; }
    }

    public void Dead()
    { gameplay.Kill++; } //Kill count. Jk it's for the waves.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Les")) //Attacking Les
        { anim.GetComponent<Animator>().Play("Cultist_AttackL"); }

        if (collision.CompareTag("Bullet")) //Getting hit
        {
            Health--;
            Instantiate(bulletDropPrefab, bulletPlace.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }

    public void Attack()
    { attack = true; }
}
