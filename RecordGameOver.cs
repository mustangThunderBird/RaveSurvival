using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordGameOver : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            if(GetEnemyKillCount.isJoeKilled)
            {
                FindObjectOfType<UiText>().SetPickUpWeaponText(6);
                if (Input.GetKey("e"))
                {
                    FindObjectOfType<UiText>().SetGameOverText(1);
                }

            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        FindObjectOfType<UiText>().SetPickUpWeaponText(0);
    }
}
