using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    public GameObject player;
    public Transform playerTransform;
    public int health = 5;

    void Start()
    {
        player = Instantiate(playerPrefab) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = player.transform;
        GetEnemyKillCount.health = health;
       if(health == 0)
        {
            player.GetComponent<PlayerController>().isControllable = false;
            //player.GetComponentInChildren<ShootGun>().isShootable = false;
            player.GetComponentInChildren<ThirdPersonCameraControl>().isControllable = false;
        }
    }
    public Transform Pt()
    {
        return playerTransform;
    }
    public void isHit()
    {
        if(health <= 0)
        {
            health = 0;
        }
        else
        {
            health--;
        }
    }
}
