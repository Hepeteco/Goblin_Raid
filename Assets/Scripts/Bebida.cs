using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bebida : MonoBehaviour {

    public Animator anim;
    public GameObject player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, -2);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("Anao", true);
            anim.SetBool("Archer", false);
            anim.SetBool("Slayer", false);
            main.POWERUP = true;
            main.SLAYER = false;
            main.ANAO = true;
            main.ARCHER = false;
            Destroy(gameObject);
        }
    }
}
