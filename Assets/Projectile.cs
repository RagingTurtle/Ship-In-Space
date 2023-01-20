using System.Collections;
using System.Collections.Generic;

using UnityEngine;
public class Projectile : MonoBehaviour
{
    private Vector3 moveDirection;
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void SetMoveDirection(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }
}