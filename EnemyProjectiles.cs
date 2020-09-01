using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectiles : MonoBehaviour
{
    public GameObject projectile;
    public Transform shootingLocation;

    public float fireRate = 4f;
    private float lastShot = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > fireRate + lastShot)
        {
            Instantiate(projectile, shootingLocation.position, shootingLocation.rotation);
            lastShot = Time.time;
        }
    }
}
