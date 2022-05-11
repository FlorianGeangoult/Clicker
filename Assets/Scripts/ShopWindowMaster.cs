using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindowMaster : MonoBehaviour
{
    public float msToWait;

    public long lastShopOpen;

    public InventoryUI ui;

    public int id;

    public Button shopButton;

    public Text timer;

    public Image spriteHolder;

    public ShopType type;

    void Start()
    {
        ui = InventoryUI.instance;
        if (IsShopReady())
        {
            shopButton.gameObject.SetActive(true);
        }
        else
        {
            shopButton.gameObject.SetActive(false);
        }
    }

    public bool IsShopReady()
    {
        if (PlayerPrefs.HasKey("Shop element : " + this.id))
        {
            var oldTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("Shop element : " + this.id)));
            var currentTime = DateTime.Now;
            TimeSpan difference = currentTime.Subtract(oldTime);
            var m = (float)difference.TotalSeconds;
            float secondsLeft = (float)(msToWait - m);


            if (secondsLeft < 0)
                return true;

            return false;
        }
        else
        {
            return true;
        }
    }
}

[System.Serializable]
public enum ShopType { LostSoul, Trinket, SoulFragment }