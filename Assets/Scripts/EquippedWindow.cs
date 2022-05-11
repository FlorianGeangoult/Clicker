using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedWindow : InventoryWindow
{
    public EquipmentSlot slot;

    public Button equip;
    public Button enhance;


    public void SetUp(EquipmentSlot s)
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

    public void unequipTrinket()
    {
        this.slot.Unequip();
        this.gameObject.SetActive(false);
    }
}
