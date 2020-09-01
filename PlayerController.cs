using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //needed for movementz
    public float speed = 10f;
    private float horizontalInput;
    private float verticalInput;

    //needed for jumping
    private float jumpForce = 7.5f;
    public float gravityModifer;
    private bool isGrounded;
    Rigidbody rb;
    public bool isControllable =true;
    Animator anim;
    public bool resetAmmo = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifer;
        anim = GetComponent<Animator>();
        SetRigidBodyState(true);
        SetColliderState(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isControllable && Pause.isGamePaused == false)
        {
            //initalize horizontal and vertical input
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            //make the player move
            
            if(verticalInput > 0)
            {
                anim.SetInteger("State", 1);
                transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
                transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            }
            if(verticalInput < 0)
            {
                anim.SetInteger("State", 3);
                transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
                transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            }
            if (horizontalInput != 0 && verticalInput == 0)
            {
                anim.SetInteger("State", 3);
                transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
                transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            }
            if(verticalInput == 0 && horizontalInput == 0)
            {
                anim.SetInteger("State", 0);
            }
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            if (!isGrounded)
            {
                anim.SetInteger("State", 2);
            }
            if(this.transform.position.y < -2)
            {
                FindObjectOfType<SpawnPlayer>().isHit();
                FindObjectOfType<SpawnPlayer>().isHit();
                FindObjectOfType<SpawnPlayer>().isHit();
                FindObjectOfType<SpawnPlayer>().isHit();
                FindObjectOfType<SpawnPlayer>().isHit();
            }
        }
        else if (!isControllable)
        {
            GetComponent<Animator>().enabled = false;
            SetRigidBodyState(false);
            SetColliderState(true);
        }
        
    }

    private void OnCollisionEnter(Collision collsion)
    {
        isGrounded = true;
    }

    void SetRigidBodyState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    void SetColliderState(bool state)
    {
        Collider[] collliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in collliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Weapon" && Input.GetKey("e") && collision.collider.gameObject.GetComponent<PickUpWeapon>().price <= GetEnemyKillCount.money)
        {
            GetEnemyKillCount.money -= collision.collider.gameObject.GetComponent<PickUpWeapon>().price;
            gameObject.GetComponentInChildren<WeaponSwitch>().swapWeapons(collision.collider.gameObject.GetComponent<PickUpWeapon>().weaponID);
        }
    }
    public void maxAmmo()
    {
        resetAmmo = true;
    }
}
