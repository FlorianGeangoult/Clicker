using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;

    public InventoryUI ui;

    public Trinket trinket;

    void Start()
    {
        ui = InventoryUI.instance;
    }

    public void AddTrinket(Trinket t)
    {

        this.trinket = t;

        icon.sprite = trinket.icon;


    }

    public Trinket getTrinket()
    {
        return trinket;
    }

    public void InventoryClick()
    {
        EquipmentManager.instance.isAlreadyEquipped(this.trinket.trinketSlot);
        ui.showTrinketWindow(this);
    }

    public void EnhancingClick()
    {
        ui.showEnhancedWindow(this);
    }

    public void onClick()
    {
        Inventory.instance.Remove(this.trinket);
        ui.slots.Remove(this);
        EquipmentManager.instance.Equip(this.trinket);
        
        
        DestroySlot();
    }


    public void DestroySlot()
    {
        Destroy(this.gameObject);
    }

    
}
