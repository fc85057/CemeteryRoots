using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject[] weapons;

    public GameObject shop;

    int tokens;
    bool isEnabled;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
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

}
