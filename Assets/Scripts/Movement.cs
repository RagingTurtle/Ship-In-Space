using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform ship;
    [SerializeField] private float maxMoveSpeed = 12f;
    private float moveSpeed;
    const float STOP_SPEED = 0;
    private Vector3 moveDirection;
    [SerializeField] private float deceleration = .001f;
    [SerializeField] private float acceleration = .002f;
    [SerializeField] private float rotationSpeed = .002f;

    private void Start()
    {
        moveDirection = ship.forward;
        moveSpeed = STOP_SPEED;
    }
    void Update()
    {
        Move();
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
        moveSpeed = Mathf.Lerp(moveSpeed, STOP_SPEED, deceleration);
    }

    private void SpeedUp()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = Vector3.Lerp(moveDirection, ship.forward, rotationSpeed);
            moveSpeed = Mathf.Lerp(moveSpeed, maxMoveSpeed, acceleration);
        }
    }

    private void Move()
    {
        SlowDown();
        SpeedUp();
        RotatLeft();
        RotatRight();

        ship.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
