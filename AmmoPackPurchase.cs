using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPackPurchase : MonoBehaviour
{
    public int price;
    public float pickUpRate = 1.5f;
    private float lastPickUp = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Player" && Input.GetKey("e") && price <= GetEnemyKillCount.money)
        {
            if (Time.time > pickUpRate + lastPickUp)
            {
                GetEnemyKillCount.money -= price;
                collision.collider.gameObject.GetComponent<PlayerController>().maxAmmo();
                lastPickUp = Time.time;
            }
        }
    }
}
