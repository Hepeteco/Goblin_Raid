using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorVida : MonoBehaviour {

    public GameObject Vida0;
    public GameObject Vida1;
    public GameObject Vida2;
    public GameObject Vida3;
    public GameObject Vida4;

    private bool vida1 = true;
    private bool vida2 = true;
    private bool vida3 = true;
    private bool vida4 = true;

    void Update()
    {
        if (main.RECUPERA_HP)
        {
            if (!vida1 && main.VIDA == 2)
                Vida1.SetActive(true);
            else if (!vida2 && main.VIDA == 3)
                Vida2.SetActive(true);

            else if (!vida3 && main.VIDA == 4)
                Vida3.SetActive(true);

            else if (!vida4 && main.VIDA == 5)
                Vida4.SetActive(true);
        }
        if (main.VIDA == 4 && main.PLAYER_HIT)
        {
            Vida4.SetActive(false);
            vida4 = false;
        }

        else if (main.VIDA == 3 && main.PLAYER_HIT)
        {
            Vida3.SetActive(false);
            vida3 = false;
        }

        else if (main.VIDA == 2 && main.PLAYER_HIT)
        {
            Vida2.SetActive(false);
            vida2 = false;
        }
        else if (main.VIDA == 1 && main.PLAYER_HIT)
        {
            Vida1.SetActive(false);
            vida1 = false;
        }
        else if (main.VIDA == 0 && main.PLAYER_HIT)
        {
            Vida0.SetActive(false);
        }
        
    }

    private void FixedUpdate()
    {
                            
    }
}
