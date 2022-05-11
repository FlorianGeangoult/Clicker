using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrinketWindow : InventoryWindow
{
    public Button equip;
    public Button enhance;

    public InventorySlot slot;


    public void SetUp(InventorySlot s)
    {
        this.slot = s;

        this.icon.sprite = this.slot.trinket.icon;

        this.tname.text = this.slot.trinket.trinketName;

        this.statbuff1.text = this.slot.trinket.clickMod.ToString();
        this.statbuff2.text = this.slot.trinket.critMod.ToString();

    }

    public void EnhancingClick()
    {

        slot.EnhancingClick();
    }

    public void equipTrinket()
    {
        this.slot.onClick();
        this.gameObject.SetActive(false);
    }

}
