using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{

    int currentWeaponIndex = 0;
    public Weapon currentWeapon;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SwitchWeapon();
    }

    private void Update()
    {
        // sr.sprite = currentWeapon.GetComponent<Weapon>().weaponStats.sprite;
        int previousWeapon = currentWeaponIndex;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentWeaponIndex >= transform.childCount - 1)
                currentWeaponIndex = 0;
            else
                currentWeaponIndex++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeaponIndex <= 0)
                currentWeaponIndex = transform.childCount - 1;
            else
                currentWeaponIndex--;
        }

        if (previousWeapon != currentWeaponIndex)
            SwitchWeapon();

    }

    void SwitchWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == currentWeaponIndex)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }

        currentWeapon = transform.GetChild(currentWeaponIndex).GetComponent<Weapon>();
        sr.sprite = currentWeapon.weaponStats.sprite;

        // sr.sprite = transform.GetChild(currentWeaponIndex).GetComponent<Weapon>().weaponStats.sprite;
    }

}
