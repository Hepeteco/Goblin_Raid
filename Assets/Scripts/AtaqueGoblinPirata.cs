using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueGoblinPirata : MonoBehaviour {

    public GameObject balaCanhao;
    private Rigidbody2D balaCanhaorb;
    public float velY;
    public float dano;
    // Use this for initialization
    void Start()
    {
        balaCanhaorb = balaCanhao.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        balaCanhaorb.velocity = new Vector2(0, velY);
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
