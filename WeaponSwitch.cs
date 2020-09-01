using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;
    public int primary = 0;
    public int secondary = -1;
    private bool isScrollable = false;
    // Start is called before the first frame update
    void Start()
    {
        switchWeapons();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if (isScrollable)
        {
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                if (selectedWeapon != primary)
                {
                    selectedWeapon = primary;
                }
                else
                {
                    selectedWeapon = secondary;
                }
            }

        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            switchWeapons();
        }
    }
    public void switchWeapons()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
    public void swapWeapons(int weaponId)
    {
        if(weaponId == primary || weaponId == secondary)
        {
            //do nothing
        }
        else
        {
            if (!isScrollable)
            {
                secondary = weaponId;
                selectedWeapon = secondary;
            }
            else
            {
                if (selectedWeapon == primary)
                {
                    primary = weaponId;
                    selectedWeapon = primary;
                }
                else
                {
                    secondary = weaponId;
                    selectedWeapon = secondary;
                }
            }
            switchWeapons();
            isScrollable = true;
        }
    }
}
