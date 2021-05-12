using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour {

    public GameObject Ui;

    private void Start()
    {
        Ui.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !main.PAUSE)
        {
            main.PAUSE = true;
        }

       else  if (Input.GetKeyDown(KeyCode.Escape) && main.PAUSE)
        {
            main.PAUSE = false;
        }

        if (main.PAUSE)
        {
            Ui.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Ui.SetActive(false);
        main.PAUSE = false;

    }
}
