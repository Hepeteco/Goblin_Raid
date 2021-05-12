using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenarioMov : MonoBehaviour {

    Vector2 inicio;
    void Start()
    {
        inicio = new Vector2(transform.position.x, transform.position.y);   
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.down * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Limite")
            transform.position = inicio;
    }
}
