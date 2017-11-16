using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject Player;
    public int coins;
    public int dist;

    public float timer;

	// Use this for initialization
	void Start () {
        coins = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y+dist, Player.transform.position.z);
        timer += Time.deltaTime;
	}
}
