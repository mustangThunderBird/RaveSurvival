using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    public bool isShootable = true;
    public int ammo = 50;
    public GameObject objectHit;
    public bool hitEnemy = false;
    public LineRenderer lineRenderer;
    public bool isPistolActive = true;
    public bool isAssaultRifleActive = false;
    public GameObject pistol;
    public GameObject machineGun;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] initLaserPos = new Vector3[2] { Vector3.zero, Vector3.zero };
        lineRenderer.SetPositions(initLaserPos);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.enabled = false;
        if(isShootable && Pause.isGamePaused == false)
        {
            if (pistol.activeSelf)
            {
                if (Input.GetButtonDown("Fire1") && Pause.isGamePaused == false)
                {
                    FireGun();
                    lineRenderer.enabled = true;
                }
            }
            if(!pistol.activeSelf)
            {
               // GameObject.FindGameObjectWithTag("Pistol").SetActive(false);
            }
           if(machineGun.activeSelf)
            {
                //GameObject.FindWithTag("Machine Gun").SetActive(true);
                if (Input.GetButton("Fire1"))
                {
                    Invoke("doNothing", 1f);
                    FireGun();
                    lineRenderer.enabled = true;
                }
            }
        if(ammo <= 0)
            {
                ammo = 0;
            }
        }
        if(ammo == 0)
        {
            isShootable = false;
        }
        if(ammo>0)
        {
            isShootable = true;
        }
    }

    void FireGun()
    {

        ammo--;
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        Vector3 endPos = firePoint.position + (20 * firePoint.forward);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 20))
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
    }
    public void doNothing()
    {

    }
}
