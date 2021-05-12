using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPadrao : MonoBehaviour {

    public GameObject adaga;
    Vector2 adagapos;
    private Rigidbody2D rb;
    public float vel;
    private bool delay = false;
    public float cd;
    private float tempoAtaque = 0;
    VidaInimigo vida;
    private bool morreu = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        vida = GetComponent<VidaInimigo>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = new Vector2(0, vel);

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
        adagapos = new Vector2(transform.position.x, transform.position.y - 1.5f);
        Instantiate(adaga, adagapos, Quaternion.identity);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "LimiteInimigo")
            Destroy(gameObject);
    }
}
