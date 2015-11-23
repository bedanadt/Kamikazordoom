﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    public Vector2 speed = new Vector2(10, 10);
    public float scrollingspeed = 3f;
    private Vector2 movement;
    private Rigidbody2D m_Rigidbody;
    private Transform m_Transform;
    // Use this for initialization
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Transform = GetComponent<Transform>();
    }

//    void Start()
//    {
//        scrollingspeed = GameObject.Find("Manager").GetComponent<GameManager>().m_scrollvelocity;
//    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        movement = new Vector2((speed.x * inputX) + scrollingspeed, speed.y * inputY);
    }

    void FixedUpdate()
    {

        m_Rigidbody.velocity = movement;
    }
}

