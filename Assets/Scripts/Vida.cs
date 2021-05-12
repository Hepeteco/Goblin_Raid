using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Vida : MonoBehaviour {
    public float vidaAtual;
    private float cd = 1;
    private float renova = 0;
    private float renovaCura = 0;
    private float cdCura = 20;

    void Start()
    {
         vidaAtual = main.VIDA;
    }

    private void FixedUpdate()
    {
        if (renova > 0)
        {
            main.PLAYER_HIT = true;
            renova -= Time.deltaTime;
        }
        else
            main.PLAYER_HIT = false;

        if (main.CONTADOR % 5 == 0 && main.CONTADOR !=0)
            main.RECUPERA_HP = true;
        else if (main.CONTADOR % 5 != 0)
            renovaCura = 0;
    }

    void Update()
    {
        if (main.VIDA != 5 && main.RECUPERA_HP)
        {
            if (renovaCura <= 0)
            {
                renovaCura = cdCura;
                main.RECUPERA_HP = false;
                main.VIDA++;
            }
            else
                main.RECUPERA_HP = false;
        }
        if (renovaCura > 0)
            renovaCura -= Time.deltaTime;
    }

    public void TomaDano(int danoParaAplicar)
    {
        renova = cd;               
        main.VIDA -= danoParaAplicar;
        if (main.VIDA <= 0)
        {
            Morre();
        }
    }


    void Morre()
    {
        main.VIDA = 0;
    }

}
