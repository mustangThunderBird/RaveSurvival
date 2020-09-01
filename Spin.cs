using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 3;
    Rigidbody rb;
    public float gravityModifier = 1;
    private float jumpForce = 10.0f;
    //private bool isGrounded = true;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(0, speed, 0);
        //if(isGrounded)
        //{
        //WaitForSeconds(Random.Range(0, 5f));
        Invoke("Dance", Random.Range(0, 3f));
        //isGrounded = false;
        //}
    }
    /*
    private void OnCollisionEnter(Collision collsion)
    {
        isGrounded = true;
    }
    public void jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    */
    public void Dance()
    {
        animator.SetInteger("State", Random.Range(0, 5));
    }
}
