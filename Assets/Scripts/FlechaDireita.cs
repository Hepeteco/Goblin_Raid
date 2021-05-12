using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaDireita : MonoBehaviour
{
    public GameObject flechaD;
    private Rigidbody2D flechaDrb;
    public float velX;
    public float velY;
    public float dano;
    // Use this for initialization
    void Start()
    {
        flechaDrb = flechaD.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flechaDrb.velocity = new Vector2(velX, velY);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Inimigo")
        {
            col.SendMessageUpwards("TomaDano", dano);
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "LimiteProjetil")
            Destroy(gameObject);
    }
}
