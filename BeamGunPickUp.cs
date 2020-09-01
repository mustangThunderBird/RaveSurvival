using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamGunPickUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            FindObjectOfType<UiText>().SetPickUpWeaponText(3);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        FindObjectOfType<UiText>().SetPickUpWeaponText(0);
    }
}
