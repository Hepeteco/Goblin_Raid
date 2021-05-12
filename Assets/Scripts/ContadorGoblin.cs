using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorGoblin : MonoBehaviour {
    Text contador; 

	// Use this for initialization
	void Start () {
        contador = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        contador.text = "" + main.CONTADOR;
	}
}
