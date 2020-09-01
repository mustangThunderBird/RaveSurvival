using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncerPickUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            FindObjectOfType<UiText>().SetPickUpWeaponText(4);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        FindObjectOfType<UiText>().SetPickUpWeaponText(0);
    }
}
