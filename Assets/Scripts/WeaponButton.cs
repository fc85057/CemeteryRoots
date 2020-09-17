using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour
{
    public GameObject weapon;
    
    public int tokenCost;
    public bool isBought;

    public WeaponStats weaponStats;

    public Button button;
    public Text nameText;
    public Text tokenText;
    
    private void Start()
    {
        weaponStats = weapon.GetComponent<Weapon>().weaponStats;
        //button = GetComponent<Button>();
        tokenCost = weaponStats.tokenCost;
        nameText.text = weaponStats.name;
        tokenText.text = weaponStats.tokenCost.ToString();
    }

    public void SetButton(bool isActive)
    {
        button.interactable = isActive;
    }

    public void Buy()
    {
        isBought = true;
        GameManager.Instance.AddWeapon(weapon);
    }


}
