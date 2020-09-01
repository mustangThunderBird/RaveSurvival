using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunShoot : MonoBehaviour
{
    public int pelletCount;
    public float pelletFireVelocity = 30f;
    public float spreadAngle;
    public GameObject pellet;
    List<Quaternion> pellets;

    public float fireRate = 0.5f;
    private float lastShot = 0.0f;

    public int maxAmmo;
    private int ammo;

    public bool isShootable = true;

    // Start is called before the first frame update
    private void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }
    private void Start()
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
        if(isShootable && Pause.isGamePaused == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Time.time > fireRate + lastShot)
                {
                    ShootShotGun();
                    gameObject.GetComponent<AudioSource>().Play();
                    lastShot = Time.time;
                    ammo--;
                    GetEnemyKillCount.ammo = ammo;
                }
                if (ammo <= 0)
                {
                    ammo = 0;
                }
            }
        }
        if (ammo == 0)
        {
            isShootable = false;
        }
        if (ammo > 0)
        {
            isShootable = true;
        }
    }

    private void ShootShotGun()
    {
        for (int i = 0; i < pellets.Count; i++)
        {
            Quaternion quat = pellets[i];
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, gameObject.transform.GetChild(0).position, transform.GetChild(0).rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            lastShot = Time.time;
        }
    }
}
