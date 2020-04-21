﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;                //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public Transform firePoint;
    public GameObject bullet;
    public Joystick joystick;
    public static bool alive;

    // Use this for initialization
    void Start()
    {
        alive = true;
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        //float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveHorizontal = joystick.Horizontal;

        //Store the current vertical input in the float moveVertical.
        //float moveVertical = Input.GetAxis ("Vertical");
        float moveVertical = joystick.Vertical;

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce (movement * speed);
    }

    
}
