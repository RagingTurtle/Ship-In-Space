using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    private float timeSinceLastShot;
    [SerializeField] private float rateOfFire;

    private void Start()
    {
        timeSinceLastShot = float.PositiveInfinity;
    }

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKey(KeyCode.Space) && (timeSinceLastShot >= rateOfFire))
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            if (projectile != null)
            {
                projectile.GetComponent<Projectile>().SetMoveDirection(transform.forward);
            }
            ResetShotTimer();
        }
        timeSinceLastShot += Time.deltaTime;
    }

    private void ResetShotTimer()
    {
        timeSinceLastShot = 0f;
    }
}
