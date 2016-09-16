﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {


    private GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
