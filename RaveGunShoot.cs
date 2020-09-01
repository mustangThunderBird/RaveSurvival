using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaveGunShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    public bool isShootable = true;
    public GameObject objectHit;
    public bool hitEnemy = false;
    public LineRenderer lineRenderer;

    public float fireRate = 1.0f;
    private float lastShot = 0.0f;

    public int maxAmmo;
    private int ammo;

    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPos = new Vector3[2] { Vector3.zero, Vector3.zero };
        lineRenderer.SetPositions(initLaserPos);
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
        if (gameObject.activeSelf)
        {
            lineRenderer.enabled = false;
            if (isShootable && Pause.isGamePaused == false)
            {
                if (Input.GetButton("Fire1"))
                {
                    if (Time.time > fireRate + lastShot)
                    {
                        FireGun();
                        lineRenderer.enabled = true;
                        lastShot = Time.time;
                    }
                }
                if (ammo <= 0)
                {
                    ammo = 0;
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
    }

    void FireGun()
    {
        gameObject.GetComponent<AudioSource>().Play();
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        Vector3 endPos = firePoint.position + (20 * firePoint.forward);
        RaycastHit hitInfo;
        ammo--;
        if (Physics.Raycast(ray, out hitInfo, 20))
        {
            endPos = hitInfo.point;
            objectHit = hitInfo.collider.gameObject;
            if (objectHit.tag == "Enemy" || objectHit.tag == "BruhEnemy" || objectHit.tag == "CringeEnemy")
            {
                hitEnemy = true;
                GetEnemyKillCount.lastObjectHit = objectHit.tag;
                objectHit.GetComponent<EnemyController>().EnemyTakeDamage(500);
            }
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, endPos);
        GetEnemyKillCount.ammo = ammo;
    }
}
