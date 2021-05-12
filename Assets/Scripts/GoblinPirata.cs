using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPirata : MonoBehaviour {

    public GameObject balaCanhao;
    Vector2 balacanhaoapos;
    public GameObject balaCanhaoD;
    Vector2 balacanhaoaposD;
    public GameObject balaCanhaoE;
    Vector2 balacanhaoaposE;
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
        balacanhaoapos = new Vector2(transform.position.x, transform.position.y - 1.5f);
        balacanhaoaposD = new Vector2(balacanhaoapos.x + 1f, transform.position.y - 1.5f);
        balacanhaoaposE = new Vector2(balacanhaoapos.x + -1f, transform.position.y - 1.5f);
        Instantiate(balaCanhao, balacanhaoapos, Quaternion.identity);
        Instantiate(balaCanhaoD, balacanhaoaposD, Quaternion.Euler(0, 0, 30));
        Instantiate(balaCanhaoE, balacanhaoaposE, Quaternion.Euler(0, 0, -30));

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "LimiteInimigo")
            Destroy(gameObject);
    }
}
