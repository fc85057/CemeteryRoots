using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject weaponPrefab;
    // public GameObject[] weapons;
    public WeaponButton[] weaponButtons;

    public GameObject shop;

    int tokens;
    bool isEnabled;

    private void Start()
    {
        
    }

    private void Update()
    {
        tokens = GameManager.Instance.GetTokens();

        foreach(var weaponButton in weaponButtons)
        {
            if (tokens >= weaponButton.weaponStats.tokenCost && (!weaponButton.isBought))
            {
                weaponButton.SetButton(true);
            }
            else
            {
                weaponButton.SetButton(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) && !(GameManager.Instance.gameOver))
            SetShopStatus();
    }

    void SetShopStatus()
    {
        if (!isEnabled)
        {
            isEnabled = true;
            shop.SetActive(true);
            GameManager.Instance.player.enabled = false;
            Time.timeScale = 0.1f;
        }
        else
        {
            isEnabled = false;
            shop.SetActive(false);
            GameManager.Instance.player.enabled = true;
            Time.timeScale = 1f;
        }
    }

    public void SpawnWeapon(GameObject weapon)
    {
        GameManager.Instance.SetTokens(-weapon.GetComponent<Weapon>().weaponStats.tokenCost);
        GameObject newWeapon = Instantiate(weapon, weaponSlot);
        // newWeapon.GetComponent<Weapon>().weaponStats = weaponStats;
        newWeapon.SetActive(false);
    }

}
