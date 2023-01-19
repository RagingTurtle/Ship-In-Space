using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform ship;
    [SerializeField] private float maxSpeed = .5f;
    private float speed;
    private Vector3 moveDirection;
    [SerializeField] private float slowDownAmount = .001f;
    [SerializeField] private float speedUpAmount = .001f;
    [SerializeField] private float moveAdjustmentAmount = .001f;

    private void Start()
    {
        moveDirection = ship.forward;
        speed = 0;
    }
    void Update()
    {
        SlowDown();
        Thrust();
        Move();
        RotatLeft();
        RotatRight();
        print(speed);
    }

    private void RotatLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ship.Rotate(Vector3.left);
        }
    }
    private void RotatRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ship.Rotate(Vector3.right);
        }
    }

    private void SlowDown()
    {
        speed = Mathf.Lerp(speed, 0, slowDownAmount);
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = Vector3.Lerp(moveDirection, ship.forward, moveAdjustmentAmount);
            speed = Mathf.Lerp(speed, maxSpeed, speedUpAmount);
        }
    }

    private void Move()
    {
        ship.position += moveDirection * speed * Time.deltaTime;
    }
}
