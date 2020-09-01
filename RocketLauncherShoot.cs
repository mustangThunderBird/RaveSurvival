using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherShoot : MonoBehaviour
{
    public GameObject rocket;
    public bool isShootable;

    public float fireRate = 1.0f;
    private float lastShot = 0.0f;

    public int maxAmmo;
    private int ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<PlayerController>().resetAmmo)
        {
            ammo = maxAmmo;
            GetComponentInParent<PlayerController>().resetAmmo = false;
        }
        if (ammo != GetEnemyKillCount.ammo)
        {
            GetEnemyKillCount.ammo = ammo; ;
        }
        if (GetEnemyKillCount.ammo > maxAmmo)
        {
            GetEnemyKillCount.ammo = maxAmmo;
        }
        {
            isShootable = false;
        }
        if (ammo > 0)
        {
            isShootable = true;
        }
        if(isShootable && Pause.isGamePaused == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Time.time > fireRate + lastShot)
                {
                    gameObject.GetComponent<AudioSource>().Play();
                    lastShot = Time.time;
                    Instantiate(rocket, gameObject.transform.GetChild(2).position, gameObject.transform.rotation);
                    ammo--;
                    if (ammo < 1)
                    {
                        ammo = 0;
                    }
                    GetEnemyKillCount.ammo = ammo;
                }
            }
        }
    }
}
