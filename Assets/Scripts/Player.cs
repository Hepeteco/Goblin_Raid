using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rb;
    public float vel;
    private bool ataqueBasico = false;
    public GameObject espada;
    public float espadaVel;
    private bool move;
    Vector2 espadapos;
    private bool delay = false;
    public float cd;
    public float cdAnao;
    private float tempoAtaque;
    Vector2 flechapos;
    Vector2 flechaDpos;
    Vector2 flechaEpos;
    Vector2 pedrapos;
    Vector2 pedrapos2;
    public GameObject flecha;
    public GameObject flechaD;
    public GameObject flechaE;
    public GameObject pedra;
    public float timerPowerUp;
    private float cdPowerUp;
    private Animator anim;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (move)
        {
            if(Input.GetAxis("Horizontal") > 0)
                rb.velocity = new Vector2(vel, 0);
            else
                rb.velocity = new Vector2(-vel, 0);
        }
        else
            rb.velocity = Vector2.zero;
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
            move = true;
        else 
            move = false;

            if (Input.GetButton("AtaqueBasico"))
            ataqueBasico = true;
        else
            ataqueBasico = false;

            if(main.POWERUP)
            {
            cdPowerUp = timerPowerUp;
            main.POWERUP = false;
            }

        if (cdPowerUp > 0)
            cdPowerUp -= Time.deltaTime;
        else
        {
            anim.SetBool("Anao", false);
            anim.SetBool("Archer", false);
            anim.SetBool("Slayer", true);
            main.POWERUP = false;
            main.ARCHER = false;
            main.ANAO = false;
            main.SLAYER = true;
        }
        if (ataqueBasico && !delay && !main.ANAO)
        {
            delay = true;
            tempoAtaque = cd;
            if (main.SLAYER && !main.POWERUP)
                AtaqueBasico();
            else if (main.ARCHER)
                AtaqueArcher();
        }
        else if((ataqueBasico && !delay && main.ANAO))
        {
            delay = true;
            tempoAtaque = cdAnao;
            AtaqueAnao();
        }

        if (delay)
        {
            if (tempoAtaque > 0)
                tempoAtaque -= Time.deltaTime;

            else
                delay = false;
        }
       float x = Mathf.Clamp(transform.position.x, -6.52f, 9.62f);
        transform.position = new Vector2(x, transform.position.y);
    }


    void AtaqueBasico()
    { 
        espadapos = new Vector2(transform.position.x, 1.5f);
        Instantiate(espada, espadapos, Quaternion.identity);
        
    }

    void AtaqueArcher ()
    {
        flechapos = new Vector2(transform.position.x, 1.5f);
        flechaDpos = new Vector2(flechapos.x + 1f, 1.5f);
        flechaEpos = new Vector2(flechapos.x - 1f, 1.5f);
        Instantiate(flecha, flechapos, Quaternion.identity);
        Instantiate(flechaD, flechaDpos, Quaternion.Euler(0,0,-45));
        Instantiate(flechaE, flechaEpos, Quaternion.Euler(0,0,45));
    }
    
    void AtaqueAnao()
    {
        pedrapos = new Vector2(transform.position.x - 0.2f, 1.5f);
        pedrapos2 = new Vector2(transform.position.x + 0.2f, 1.5f);
        Instantiate(pedra, pedrapos, Quaternion.identity);
        Instantiate(pedra, pedrapos2, Quaternion.identity);
    }
}
