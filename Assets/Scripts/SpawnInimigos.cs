using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInimigos : MonoBehaviour {
    public Transform spawnZoneMin;
    public Transform spawnZoneMax;
    public GameObject goblinPadrao;
    public GameObject goblinPirata;
    public float spawnTimeGoblinPadrao;
    private Vector2 spawnZone;
    public float cd;
    public float cdPirata;
    public GameObject SpawnZoneBoss;
    public GameObject Boss;

	// Use this for initialization
	void Start () {
    
        if (spawnTimeGoblinPadrao > 0)
            InvokeRepeating("SpawnGoblinPadrao", cd, cd);
        if (spawnTimeGoblinPadrao > 0)
            InvokeRepeating("SpawnGoblinPirata", 5, cdPirata);
        if (spawnTimeGoblinPadrao > 0)
            Invoke("SpawnaBoss", spawnTimeGoblinPadrao);
    }
	
	// Update is called once per frame
	void Update () {
        spawnTimeGoblinPadrao -= Time.deltaTime;
        
    }

    private void LateUpdate()
    {
        if (spawnTimeGoblinPadrao <= 0)
        {
            CancelInvoke("SpawnGoblinPadrao");
            CancelInvoke("SpawnGoblinPirata");
        }       
    }

    void SpawnGoblinPadrao()
    {
        spawnZone = new Vector2(Random.Range(spawnZoneMin.position.x, spawnZoneMax.position.x), spawnZoneMin.transform.position.y);
        Instantiate(goblinPadrao, spawnZone, Quaternion.identity);
    }

    void SpawnGoblinPirata()
    {
        spawnZone = new Vector2(Random.Range(spawnZoneMin.position.x, spawnZoneMax.position.x), spawnZoneMin.transform.position.y);
        Instantiate(goblinPirata, spawnZone, Quaternion.identity);
    }

    void SpawnaBoss()
    {
        Instantiate(Boss, SpawnZoneBoss.transform.position, Quaternion.identity);
    }
}
