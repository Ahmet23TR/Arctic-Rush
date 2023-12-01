using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float maxSpeed = 30f;
    [SerializeField] float normalSpeed = 20f;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            ResponBoost();
        } 
        else 
        {
            DisabledControls();
        }
    }

    public void DisabledControls()
    {
        canMove = false;
    }

    void ResponBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = maxSpeed;
        }
        else 
        {
            surfaceEffector2D.speed = normalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
