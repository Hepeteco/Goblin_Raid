using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaEsquerda : MonoBehaviour {
    public GameObject flechaE;
    private Rigidbody2D flechaErb;
    public float velX;
    public float velY;
    public float dano;
    // Use this for initialization
    void Start () {
        flechaErb = flechaE.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        flechaErb.velocity = new Vector2(velX, velY);
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
