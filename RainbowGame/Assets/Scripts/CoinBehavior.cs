using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour {

    private Rigidbody rb;
    private CapsuleCollider col;
    private bool ascending;

    public GameObject player_camera;
    private SoundManager sound;

    private void Start()
    {
        ascending = true;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        sound = GameObject.Find("AudioPlayer").GetComponent<SoundManager>();
    }

    private void Update()
    {
        this.transform.Rotate(0, 5, 0);
        Bob();
    }

    private void Bob()
    {
        if (ascending)
        {
            rb.velocity += new Vector3(0, .1f, 0);
            if(rb.velocity.magnitude > 1)
            {
                ascending = false;
            }
        }
        else if (!ascending)
        {
            rb.velocity -= new Vector3(0, .1f, 0);
            if(rb.velocity.magnitude > 1)
            {
                ascending = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //Do something in the world...whatever we decide to do.
            sound.PlayCoinSound();
            player_camera.GetComponent<CameraFollow>().coins += 1;
            Destroy(this.gameObject);
        }
    }




}
