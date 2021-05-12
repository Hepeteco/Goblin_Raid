using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueGoblinPadrao: MonoBehaviour
{
    public float velY = 0;
    Rigidbody2D rb;
    private float dano = 1;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(0, velY);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.SendMessageUpwards("TomaDano", dano);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "LimiteInimigo")
            Destroy(gameObject);

    }
}
