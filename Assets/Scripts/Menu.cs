using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public GameObject Controles;

    void Start()
    {
        Controles.SetActive(false);    
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && main.CONTROLES && !main.PAUSE)
            CloseOptions();

        if (!main.CONTROLES)
        {
            Controles.SetActive(false);
        }
    }

    public void StarGame()
    {
        SceneManager.LoadScene("Jogo", LoadSceneMode.Single);
    }

    public void Options()
    {
        main.CONTROLES = true;
        Controles.SetActive(true);
    }
    public void CloseOptions()
    {
        Controles.SetActive(false);
    }
}
