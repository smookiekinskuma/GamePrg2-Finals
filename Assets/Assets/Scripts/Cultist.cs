using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cultist : MonoBehaviour
{
    public Player player;
    public Gameplay gameplay;

    //Cultist Moving
    public float moveSpeed;
    public Vector2 movementInput;
    public Rigidbody2D rigidBody;
    public Animator anim;

    public Transform bulletPlace;
    public GameObject bulletDropPrefab;

    //Health
    public int Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = 5;
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dead. lol.
        if (Health == 0)
        {
            anim.GetComponent<Animator>().Play("Cultist_Dead");
            Destroy(GameObject.FindWithTag("Cultist"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Les"))
        {
            player.Health--;
            anim.GetComponent<Animator>().Play("Cultist_AttackL");
        }

        if (collision.CompareTag("Bullet"))
        {
            Health--;
            Instantiate(bulletDropPrefab, bulletPlace.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }
}
