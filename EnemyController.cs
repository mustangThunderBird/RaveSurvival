using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 1;
    private SpawnManager spawnManagerScript;
    public bool alive = true;
    public GameObject spawnManager;
    Animator animator;
    public static bool enemyKilled = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        SetRigidBodyState(true);
        setColliderState(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            GetEnemyKillCount.killCount++;
            GetEnemyKillCount.totalKills++;
            if(GetEnemyKillCount.lastObjectHit == "Enemy")
            {
                GetEnemyKillCount.money += 10;
                GetEnemyKillCount.moneyIncrease = 10;
            }
            else if(GetEnemyKillCount.lastObjectHit == "BruhEnemy")
            {
                GetEnemyKillCount.money += 25;
                GetEnemyKillCount.moneyIncrease = 25;
            }
            else if(GetEnemyKillCount.lastObjectHit == "CringeEnemy")
            {
                GetEnemyKillCount.money += 100;
                GetEnemyKillCount.moneyIncrease = 100;
            }
            else if (GetEnemyKillCount.lastObjectHit == "JoeEnemy")
            {
                GetEnemyKillCount.money += 1000;
                GetEnemyKillCount.moneyIncrease = 1000;
            }
            Die();
            enemyKilled = true;
            alive = true;
        }
        if(transform.position.y < -.5)
        {
            Destroy(gameObject);
        }
        
    }

    public void EnemyTakeDamage(int damage)
    {
        health = health - damage;
        if(health<=0)
        {
            alive = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {          
            FindObjectOfType<SpawnPlayer>().isHit();
        }
    }

    void SetRigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void setColliderState(bool state)
    {
        Collider[] collliders = GetComponentsInChildren<Collider>();

        foreach(Collider collider in collliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }

    void Die()
    {
        GetComponent<Animator>().enabled = false;
        SetRigidBodyState(false);
        setColliderState(true);
        Destroy(gameObject, 2f);
    }
}
