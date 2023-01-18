using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform ship;
    [SerializeField] private float speed = .5f;
    private KeyCode pressedButton;

    void Update()
    {
        Thrust();
        RotatLeft();
        RotatRight();
    }

    private void RotatLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ship.Rotate(0, -1, 0);
        }
    }
    private void RotatRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            ship.Rotate(0, 1, 0);
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ship.position += ship.forward * speed * Time.deltaTime;
        }
    }
}
