﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public Vector3 spawnValues;
    // Use this for initialization
    void Start()
    {
       // spawnPlayer();
        //spawnEnemies();
    }

   /* void spawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(0,0,0);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(player, spawnPosition, spawnRotation);
    }*/

    void spawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(spawnValues.y, -spawnValues.y), spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(enemy, spawnPosition, spawnRotation);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
