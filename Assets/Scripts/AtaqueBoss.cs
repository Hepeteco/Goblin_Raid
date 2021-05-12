using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBoss : MonoBehaviour
{

    public GameObject fogo;
    private Rigidbody2D fogorb;
    public float velX;
    public float velY;
    public float dano;
    // Use this for initialization
    void Start()
    {
        fogorb = fogo.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fogorb.velocity = new Vector2(velX, velY);
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
