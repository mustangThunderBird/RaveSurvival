using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<PlayerController>().maxAmmo();
            GetEnemyKillCount.ammo += 100;
            Destroy(gameObject);
        }
    }
}
