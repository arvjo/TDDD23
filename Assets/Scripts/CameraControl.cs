﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {


    private GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
	}
}
