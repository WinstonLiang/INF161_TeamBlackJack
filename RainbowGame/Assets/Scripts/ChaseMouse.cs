using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMouse : MonoBehaviour {

    private Rigidbody rigidBody;
    private bool jump = false;
    private float distToGround;
    private SoundManager sound;
    private float diffX, diffY;

    public float thrust = 0.25f;
    public float jumpForce = 5.75f;
    public float controllerTolerance = 5.00f;

    // Use this for initialization
    void Start ()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rigidBody = GetComponent<Rigidbody>();
        sound = GameObject.Find("AudioPlayer").GetComponent<SoundManager>();
    }

    void Update()
    {
        var playerCoords = Camera.main.WorldToViewportPoint(transform.position);
        var mouseCoords = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        diffX = mouseCoords.x - playerCoords.x;
        diffY = mouseCoords.y - playerCoords.y;
        jump = Input.GetMouseButtonDown(0);
        thrust = (jump && isGrounded()) ? 0.25f : 0.5f;
    }

    void FixedUpdate()
    {
        if (jump && isGrounded())
            playerJump();
        if (Math.Abs(diffX) > controllerTolerance )
        {
            if (diffX > 0 && rigidBody.velocity.x < 5)
                rigidBody.AddForce(new Vector3(thrust, 0, 0), ForceMode.Impulse); 
            else if (diffX < 0 && rigidBody.velocity.x > -5)
                rigidBody.AddForce(new Vector3(-thrust, 0, 0), ForceMode.Impulse);
        }
        if (Math.Abs(diffY) > controllerTolerance)
        {
            if (diffY > 0 && rigidBody.velocity.z < 5)
                rigidBody.AddForce(new Vector3(0, 0, thrust), ForceMode.Impulse);
            else if (diffY < 0 && rigidBody.velocity.z > -5)
                rigidBody.AddForce(new Vector3(0, 0, -thrust), ForceMode.Impulse);
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    private void playerJump()
    {
        sound.PlayJumpSound();
        rigidBody.AddForce(new Vector3(0.0f, jumpForce, 0.0f), ForceMode.VelocityChange);
    }
}
