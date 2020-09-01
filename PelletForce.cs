using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletForce : MonoBehaviour
{
    public float force = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, force * Time.deltaTime);
        Invoke("destroyPellet", 0.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Enemy" || collision.collider.gameObject.tag == "BruhEnemy" || collision.collider.gameObject.tag == "CringeEnemy" || collision.collider.gameObject.tag == "JoeEnemy")
        {
            GetEnemyKillCount.lastObjectHit = collision.collider.gameObject.tag;
            collision.collider.GetComponent<EnemyController>().EnemyTakeDamage(5);
        };
    }
    void destroyPellet()
    {
        Destroy(gameObject);
    }
}
