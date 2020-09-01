using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPelletForce : MonoBehaviour
{
    public float force;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, force * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.collider.gameObject.tag == "Player")
        {
            FindObjectOfType<SpawnPlayer>().isHit();
            FindObjectOfType<SpawnPlayer>().isHit();
            FindObjectOfType<SpawnPlayer>().isHit();
            FindObjectOfType<SpawnPlayer>().isHit();
            FindObjectOfType<SpawnPlayer>().isHit();
        }
        Destroy(gameObject);
    }
}
