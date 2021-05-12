using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueGoblinPirataE : MonoBehaviour {

    public GameObject balaCanhaoE;
    private Rigidbody2D balaCanhaoErb;
    public float velX;
    public float velY;
    public float dano;
    // Use this for initialization
    void Start()
    {
        balaCanhaoErb = balaCanhaoE.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        balaCanhaoErb.velocity = new Vector2(velX, velY);
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
