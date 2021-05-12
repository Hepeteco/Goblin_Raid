using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour {

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
            anim.SetBool("Archer", true);
            anim.SetBool("Slayer", false);
            anim.SetBool("Anao", false);
            main.POWERUP = true;
            main.SLAYER = false;
            main.ANAO = false;
            main.ARCHER = true;
            Destroy(gameObject);
        }            
    }
}
