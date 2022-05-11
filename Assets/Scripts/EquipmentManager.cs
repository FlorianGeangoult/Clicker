using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    public PointsManager pm;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        int numSlots = System.Enum.GetNames(typeof(TrinketSlot)).Length - 1;
        trinkets = new Trinket[numSlots];
    }

    public EquipmentSlot[] slots = new EquipmentSlot[3];
    public Trinket[] trinkets;

    public InventoryUI UI;

  

    public void isAlreadyEquipped(TrinketSlot slot)
    {
        int slotIndex = (int)slot;
        Debug.Log("Slot index : " + slotIndex);
        Debug.Log("Slot index : " + slots[slotIndex]);

        if (trinkets[slotIndex] != null)
        {
            InventoryUI.instance.showEquipmentWindow(slots[slotIndex]);
        }
    }

    public void Equip(Trinket trinket)
    {
        int slotIndex = (int)trinket.trinketSlot;

        Trinket oldTrinket = null;

        if(trinkets[slotIndex] != null)
        {
            oldTrinket = trinkets[slotIndex];
            Inventory.instance.Add(oldTrinket);
            InventoryUI.instance.UpdateUI(oldTrinket.trinketSlot);
        }

        trinkets[slotIndex] = trinket;
        slots[slotIndex].AddTrinket(trinket);
        pm.addTrinketMods(trinket);
        AutoClicker.addTrinketMods(trinket);

        for (int i = 0; i < 3; i++)
        {

            if (EquipmentManager.instance.trinkets[i] != null)
            {

                Debug.Log("rentre dans la boucle d'équipement" + trinkets[i] + " " + trinkets[i].trinketSlot);
               
            }
            else
            {
                
            }
        }
    }

    public void Unequip(Trinket trinket)
    {
        int slotIndex = (int)trinket.trinketSlot;
        trinkets[slotIndex] = null;

        Inventory.instance.Add(trinket);
        InventoryUI.instance.UpdateUI(trinket.trinketSlot);
        pm.RemoveTrinketMods(trinket);
        
        AutoClicker.RemoveTrinketMods(trinket);
    }
}
