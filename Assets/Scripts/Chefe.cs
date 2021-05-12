using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chefe : MonoBehaviour {

    public GameObject fogo;
    Vector2 fogopos;
    private Rigidbody2D rb;
    public float vel;
    private bool delay = false;
    public float cd;
    private float tempoAtaque = 0;
    VidaInimigo vida;
    private bool morreu = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vida = GetComponent<VidaInimigo>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(vel, 0);

        if (!delay && !morreu)
        {
            delay = true;
            AtaqueBasico();
            tempoAtaque = cd;
        }
        if (delay)
        {
            if (tempoAtaque > 0)
                tempoAtaque -= Time.deltaTime;

            else
                delay = false;
        }
        if (vida.vidaAtual <= 0)
            morreu = true;
    }

    void AtaqueBasico()
    {
        fogopos = new Vector2(transform.position.x, transform.position.y - 1.5f);
        Instantiate(fogo, fogopos, Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Inverte")
            vel *= -1;
    }
}
