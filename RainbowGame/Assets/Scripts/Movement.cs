using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Vector3 startPosition;
    float thrust = 0.5f;
    bool hasJumped = false;
    bool landed = true;

	// Use this for initialization
	void Start () {
        startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasJumped && landed)
            thrust = 0.5f;
        else
        {
            thrust = 0.25f;
        }

        if (Input.GetKey("up") || Input.GetKey("w"))
            if(this.GetComponent<Rigidbody>().velocity.z < 5)
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, thrust), ForceMode.Impulse);
        if (Input.GetKey("down") || Input.GetKey("s"))
            if (this.GetComponent<Rigidbody>().velocity.z > -5)
                this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -thrust), ForceMode.Impulse);
        if (Input.GetKey("left") || Input.GetKey("a"))
            if (this.GetComponent<Rigidbody>().velocity.x > -5)
                this.GetComponent<Rigidbody>().AddForce(new Vector3(-thrust, 0, 0), ForceMode.Impulse);
        if (Input.GetKey("right") || Input.GetKey("d"))
            if (this.GetComponent<Rigidbody>().velocity.x < 5)
                this.GetComponent<Rigidbody>().AddForce(new Vector3(thrust, 0, 0), ForceMode.Impulse);

        if (Input.GetKey("r"))
            this.Reset();

        if (Input.GetKey("space"))
            if (!hasJumped && landed)
            {
                this.Jump();
                hasJumped = true;
                landed = false;
            }
        if (Input.GetKeyUp("space"))
        {
            hasJumped = false;
        }

	}
    
    void Reset ()
    {
        this.transform.position = startPosition;
    }

    void Jump ()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5.75f, 0), ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.position.y < this.transform.position.y)
            landed = true;
    }
}
