﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class MoviminetoTortuga : MonoBehaviour
{
    public float visionRadius;

    GameObject player;
    Vector3 InitialPosition;
    
    [Header("Movement")]
    public float maxSpeed;
    public float horizontalForce;

    [Header("Physics")]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        InitialPosition = transform.position;

        Vector3 target = InitialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius) target = player.transform.position;

        float fixedSpeed = 4 * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target,fixedSpeed);
    }

    private void FixedUpdate()
    {
    
        rb.AddForce(ForceDirection(transform.localScale.x) * horizontalForce, ForceMode2D.Force);
        LimitVelocity();
    }

    private void LimitVelocity()
    {
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }

    private Vector2 ForceDirection(float sign)
    {
        Vector2 vector;

        if (sign > 0)
            vector = Vector2.left;
        else
            vector = Vector2.right;

        return vector;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}
