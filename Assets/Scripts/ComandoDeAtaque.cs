using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComandoDeAtaque : MonoBehaviour { 

    private bool ataque = false;

    private float tempoAtaque = 0;
    private float cdAtaque = 0.3f;

    public int dano;

    public Collider2D ativaAtaque;

    // Use this for initialization
    void Awake () {
        ativaAtaque.enabled = false;
        
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && !ataque)
        {
            ataque = true;
            tempoAtaque = cdAtaque;

            ativaAtaque.enabled = true;
        }

        if (ataque)
        {
            if (tempoAtaque > 0)
                tempoAtaque -= Time.deltaTime;

            else
            {
                ataque = false;
                ativaAtaque.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Inimigo"))
            col.SendMessageUpwards("TomaDano", dano);

        else if (col.gameObject.tag == "Boss")
            col.SendMessageUpwards("TomaDano", dano);
    }
}
