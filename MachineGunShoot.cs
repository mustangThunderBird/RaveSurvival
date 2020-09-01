using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    public bool isShootable = true;
    private int ammo;
    public GameObject objectHit;
    public bool hitEnemy = false;
    public LineRenderer lineRenderer;
    public int maxAmmo;

    public float fireRate = 0.5f;
    private float lastShot = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        Vector3[] initLaserPos = new Vector3[2] { Vector3.zero, Vector3.zero };
        lineRenderer.SetPositions(initLaserPos);
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
        if(GetEnemyKillCount.ammo > maxAmmo)
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
                    FireGun();
                    lineRenderer.enabled = true;
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
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        Vector3 endPos = firePoint.position + (20 * firePoint.forward);
        RaycastHit hitInfo;
        if(Time.time > fireRate + lastShot)
        {
            gameObject.GetComponent<AudioSource>().Play();
            ammo--;
            if (Physics.Raycast(ray, out hitInfo, 20))
            {
                endPos = hitInfo.point;
                objectHit = hitInfo.collider.gameObject;
                if (objectHit.tag == "Enemy" || objectHit.tag == "BruhEnemy" || objectHit.tag == "CringeEnemy" || objectHit.tag == "JoeEnemy")
                {
                    hitEnemy = true;
                    GetEnemyKillCount.lastObjectHit = objectHit.tag;
                    objectHit.GetComponent<EnemyController>().EnemyTakeDamage(1);
                }
            }
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, endPos);
            GetEnemyKillCount.ammo = ammo;
            lastShot = Time.time;
        }
    }
}
