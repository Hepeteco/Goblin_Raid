using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject fim;
    public GameObject fimBoss;
    private float tempoParaFechar = 5;
    private float delay = 3;

    private void Start()
    {
        fim.SetActive(false);
        fimBoss.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (main.VIDA <= 0)
        {
            tempoParaFechar -= Time.deltaTime;
            fim.SetActive(true);
        }

        if(main.BOSS_MORTO)
        {
            delay -= Time.deltaTime;
            tempoParaFechar -= Time.deltaTime;
            if (delay <= 0)
                fimBoss.SetActive(true);
        }


        if (tempoParaFechar <= 0)
            Application.Quit();
    }
}
