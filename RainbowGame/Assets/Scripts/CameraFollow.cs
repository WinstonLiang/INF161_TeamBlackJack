﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;
    public int coins;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y+5, Player.transform.position.z);
	}
}
