using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    private bool isGrounded = true;

    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (GetEnemyKillCount.health == 0)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
            //agent.isStopped = true;
            transform.rotation = Quaternion.identity;
            animator.SetInteger("State", 2);
        }
        else if (gameObject.GetComponent<EnemyController>().health > 0)
        {
            agent.SetDestination(FindObjectOfType<SpawnPlayer>().player.transform.position);
            animator.SetInteger("State", 0);
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
