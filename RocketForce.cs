using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketForce : MonoBehaviour
{
    public GameObject explosionEffect;
    public Rigidbody rb;
    public float force;
    public float explosionForce = 200f;
    bool hasExploded  = false;
    public float radius = 5f;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, force * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!hasExploded)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);

            hasExploded = true;
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider neabyObject in colliders)
            {
                Rigidbody rb = neabyObject.GetComponent<Rigidbody>();
                if(neabyObject.tag == "Enemy" || neabyObject.tag == "BruhEnemy" || neabyObject.tag == "CringeEnemy")
                {
                    GetEnemyKillCount.lastObjectHit = neabyObject.tag;
                    neabyObject.GetComponent<EnemyController>().EnemyTakeDamage(100);
                    neabyObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, radius);
                }
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, radius);
                }
            }
        }
        Destroy(gameObject);
    }
}
