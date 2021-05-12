using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueGoblinPirataD : MonoBehaviour {

    public GameObject balaCanhaoD;
    private Rigidbody2D balaCanhaoDrb;
    public float velX;
    public float velY;
    public float dano;
    // Use this for initialization
    void Start()
    {
        balaCanhaoDrb = balaCanhaoD.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        balaCanhaoDrb.velocity = new Vector2(velX, velY);
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
