using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSlot : InventorySlot
{

    public void EquipmentClick()
    {
        ui.showEquipmentWindow(this);
    }
   
    public void Unequip()
    {
        this.icon.sprite = null;
        
        EquipmentManager.instance.Unequip(this.trinket);
        this.trinket = null;
    }
}
