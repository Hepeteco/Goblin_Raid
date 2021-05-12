using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour {

    public GameObject flecha;
    private Rigidbody2D flecharb;
    public float velY;
    public float dano;
    // Use this for initialization
    void Start()
    {
        flecharb = flecha.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        flecharb.velocity = new Vector2(0, velY);
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
