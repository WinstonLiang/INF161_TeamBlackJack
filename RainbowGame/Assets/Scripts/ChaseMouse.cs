using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMouse : MonoBehaviour {

    private Vector3 movement = Vector3.zero;
    private Rigidbody rigidBody;
    private bool jump = false;
    private float distToGround;

    public float speed = 18.0F;
    public float jumpForce = 5.0F;
    public float controllerTolerance = 0.01f;

    // Use this for initialization
    void Start () {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        rigidBody = GetComponent<Rigidbody>();
    }
	
    void Update()
    {
        var playerCoords = Camera.main.WorldToViewportPoint(transform.position);
        var mouseCoords = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        var diffX = mouseCoords.x - playerCoords.x;
        var diffY = mouseCoords.y - playerCoords.y;
        if (Math.Abs(diffX) > controllerTolerance)
            movement.x = diffX > 0.0f ? 1.0f : -1.0f;
        if (Math.Abs(diffY) > controllerTolerance)
            movement.z = diffY > 0.0f ? 1.0f : -1.0f;
        movement *= speed * Time.deltaTime;
        jump = Input.GetMouseButtonDown(0);
    }

    void FixedUpdate()
    {
        if (jump && isGrounded())
            rigidBody.AddForce(new Vector3(0.0f, 5.0f, 0.0f), ForceMode.Impulse);
        rigidBody.MovePosition(transform.position + movement);
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
