using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Rarity rarityValue;
    public TrinketSlot trinketValue;

    private float clickValue;
    private float critValue;
    private float autoValue;

    public Sprite sprite;

    public Sprite lantern;
    public Sprite hood;
    public Sprite oar;

    public List<LostSoul> souls = new List<LostSoul>();
    public LostSoul ls;

    public static ItemSpawner instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public LostSoul generateLostSoul()
    {
        int random = UnityEngine.Random.Range(0, 100);
        

        if(random <= 50)
        {
            ls = souls[0];
        }
        if(random > 50)
        {
            ls = souls[2];
        }

        bool isNew = true;

        foreach(LostSoul l in Inventory.instance.souls)
        {
            if(ls.pName == l.pName)
            {
                isNew = false;
                soulLevelUp(l);
                ls = l;
            }
        }

        if(isNew)
        {
            Inventory.instance.AddSoul(ls);
            InventoryUI.instance.UpdateSouls();
        }
        

        
        return ls;
    }

    public void soulLevelUp(LostSoul l)
    {
        l.level += 1;
        l.waitingTime = Mathf.Ceil(l.waitingTime - l.waitingTime * 0.02f);
        l.quantity = (int)Mathf.Ceil(l.quantity + l.quantity * 0.02f);
        l.sw.updateContent();
    }




    public Trinket createRandomItem()
    {
        clickValue = 0;
        critValue = 0;
        autoValue = 0;

        float rarity = UnityEngine.Random.Range(0.0f, 100.0f);

        if(rarity <= 50.0f)
        {
            rarityValue = Rarity.Common;
        }
        if(rarity <= 75.0f && rarity > 50.0f)
        {
            rarityValue = Rarity.Rare;
        }
        if (rarity <= 90.0f && rarity > 75.0f)
        {
            rarityValue = Rarity.Calming;
        }
        if (rarity <= 99.0f && rarity > 90.0f)
        {
            rarityValue = Rarity.Melancolic;
        }
        if (rarity > 99.0f)
        {
            rarityValue = Rarity.Ghostly;
        }


        float type = UnityEngine.Random.Range(0.0f, 90.0f);

        //Lantern equipment manager
        if (type <= 30.0f)
        {
            trinketValue = TrinketSlot.Lantern;
            sprite = lantern;
            if (rarityValue == Rarity.Common)
            {
              clickValue = UnityEngine.Random.Range(0.0f, 20.0f);

            }
            if (rarityValue == Rarity.Rare)
            {
                clickValue = UnityEngine.Random.Range(10.0f, 30.0f);

                int temp = UnityEngine.Random.Range(1,3);

                if(temp == 2)
                {
                    int temp2 = UnityEngine.Random.Range(1, 3);
                    if(temp2 == 1)
                    {
                        critValue = UnityEngine.Random.Range(0.0f, 5.0f);
                    }
                    else
                    {
                        autoValue = UnityEngine.Random.Range(0.0f, 5.0f);
                    }
                }
            }
            if (rarityValue == Rarity.Calming)
            {
                clickValue = UnityEngine.Random.Range(20.0f, 40.0f);
                int temp2 = UnityEngine.Random.Range(1, 3);
                if (temp2 == 1)
                {
                    critValue = UnityEngine.Random.Range(5.0f, 10.0f);
                }
                else
                {
                    autoValue = UnityEngine.Random.Range(5.0f, 10.0f);
                }
            }
            if (rarityValue == Rarity.Melancolic)
            {
                clickValue = UnityEngine.Random.Range(30.0f, 50.0f);
                int temp3 = UnityEngine.Random.Range(1, 3);
                if (temp3 == 1)
                {
                    critValue = UnityEngine.Random.Range(10.0f, 15.0f);
                }
                else
                {
                    autoValue = UnityEngine.Random.Range(10.0f, 15.0f);
                }

                int temp = UnityEngine.Random.Range(1, 3);

                if (temp == 2)
                {
                    int temp2 = UnityEngine.Random.Range(1, 3);
                    if (critValue == 0.0f)
                    {
                        critValue = UnityEngine.Random.Range(5.0f, 10.0f);
                    }
                    else
                    {
                        autoValue = UnityEngine.Random.Range(5.0f, 10.0f);
                    }
                }



            }
            if (rarityValue == Rarity.Ghostly)
            {
                clickValue = UnityEngine.Random.Range(40.0f, 60.0f);
                critValue = UnityEngine.Random.Range(10.0f, 20.0f);
                autoValue = UnityEngine.Random.Range(10.0f, 20.0f);
            }
        }
        //Hood equipment manager
        if (type <= 60.0f && type > 30.0f)
        {
            trinketValue = TrinketSlot.Hood;
            sprite = hood;
            if (rarityValue == Rarity.Common)
            {
                autoValue = UnityEngine.Random.Range(0.0f, 20.0f);

            }
            if (rarityValue == Rarity.Rare)
            {
                autoValue = UnityEngine.Random.Range(10.0f, 30.0f);

                int temp = UnityEngine.Random.Range(1, 3);

                if (temp == 2)
                {
                    int temp2 = UnityEngine.Random.Range(1, 3);
                    if (temp2 == 1)
                    {
                        critValue = UnityEngine.Random.Range(0.0f, 5.0f);
                    }
                    else
                    {
                        clickValue = UnityEngine.Random.Range(0.0f, 5.0f);
                    }
                }
            }
            if (rarityValue == Rarity.Calming)
            {
                autoValue = UnityEngine.Random.Range(20.0f, 40.0f);
                int temp2 = UnityEngine.Random.Range(1, 3);
                if (temp2 == 1)
                {
                    critValue = UnityEngine.Random.Range(5.0f, 10.0f);
                }
                else
                {
                    clickValue = UnityEngine.Random.Range(5.0f, 10.0f);
                }
            }
            if (rarityValue == Rarity.Melancolic)
            {
                autoValue = UnityEngine.Random.Range(30.0f, 50.0f);
                int temp3 = UnityEngine.Random.Range(1, 3);
                if (temp3 == 1)
                {
                    critValue = UnityEngine.Random.Range(10.0f, 15.0f);
                }
                else
                {
                    clickValue = UnityEngine.Random.Range(10.0f, 15.0f);
                }

                int temp = UnityEngine.Random.Range(1, 3);

                if (temp == 2)
                {
                    int temp2 = UnityEngine.Random.Range(1, 3);
                    if (critValue == 0.0f)
                    {
                        critValue = UnityEngine.Random.Range(5.0f, 10.0f);
                    }
                    else
                    {
                        clickValue = UnityEngine.Random.Range(5.0f, 10.0f);
                    }
                }



            }
            if (rarityValue == Rarity.Ghostly)
            {
                autoValue = UnityEngine.Random.Range(40.0f, 60.0f);
                critValue = UnityEngine.Random.Range(10.0f, 20.0f);
                clickValue = UnityEngine.Random.Range(10.0f, 20.0f);
            }
        }
        //Oar equipment manager
        if (type <= 90.0f && type > 60.0f)
        {
            trinketValue = TrinketSlot.Oar;
            sprite = oar;
            if (rarityValue == Rarity.Common)
            {
                critValue = UnityEngine.Random.Range(0.0f, 20.0f);

            }
            if (rarityValue == Rarity.Rare)
            {
                critValue = UnityEngine.Random.Range(10.0f, 30.0f);

                int temp = UnityEngine.Random.Range(1, 3);

                if (temp == 2)
                {
                    int temp2 = UnityEngine.Random.Range(1, 3);
                    if (temp2 == 1)
                    {
                        clickValue = UnityEngine.Random.Range(0.0f, 5.0f);
                    }
                    else
                    {
                        autoValue = UnityEngine.Random.Range(0.0f, 5.0f);
                    }
                }
            }
            if (rarityValue == Rarity.Calming)
            {
                critValue = UnityEngine.Random.Range(20.0f, 40.0f);
                int temp2 = UnityEngine.Random.Range(1, 3);
                if (temp2 == 1)
                {
                    clickValue = UnityEngine.Random.Range(5.0f, 10.0f);
                }
                else
                {
                    autoValue = UnityEngine.Random.Range(5.0f, 10.0f);
                }
            }
            if (rarityValue == Rarity.Melancolic)
            {
                critValue = UnityEngine.Random.Range(30.0f, 50.0f);
                int temp3 = UnityEngine.Random.Range(1, 3);
                if (temp3 == 1)
                {
                    clickValue = UnityEngine.Random.Range(10.0f, 15.0f);
                }
                else
                {
                    autoValue = UnityEngine.Random.Range(10.0f, 15.0f);
                }

                int temp = UnityEngine.Random.Range(1, 3);

                if (temp == 2)
                {
                    int temp2 = UnityEngine.Random.Range(1, 3);
                    if (clickValue == 0.0f)
                    {
                        clickValue = UnityEngine.Random.Range(5.0f, 10.0f);
                    }
                    else
                    {
                        autoValue = UnityEngine.Random.Range(5.0f, 10.0f);
                    }
                }



            }
            if (rarityValue == Rarity.Ghostly)
            {
                critValue = UnityEngine.Random.Range(40.0f, 60.0f);
                clickValue = UnityEngine.Random.Range(10.0f, 20.0f);
                autoValue = UnityEngine.Random.Range(10.0f, 20.0f);
            }
        }

        Trinket t = ScriptableObject.CreateInstance<Trinket>();
        t.rarity = rarityValue;
        t.trinketSlot = trinketValue;
        t.icon = sprite;
        t.clickMod = (int)Mathf.Ceil(clickValue);
        t.critMod = (int)Mathf.Ceil(critValue);
        t.autoMod = (int)Mathf.Ceil(autoValue);
        Inventory.instance.Add(t);
        return t;



    }

    public void GenerateTrinketFromData(int rarity, int slot, int clickMod, int critMod, int autoMod, bool isEquipped)
    {
        Trinket t = ScriptableObject.CreateInstance<Trinket>();
        t.rarity = (Rarity)rarity;
        t.trinketSlot = (TrinketSlot)slot;
        t.clickMod = clickMod;
        t.critMod = critMod;
        t.autoMod = autoMod;
        switch (t.trinketSlot)
        {
            case TrinketSlot.Lantern:
                 t.icon = lantern;
                break;
            case TrinketSlot.Hood:
                t.icon = hood;
                break;
            case TrinketSlot.Oar:
                t.icon = oar;
                break;
        }
        if (!isEquipped)
        {
            Inventory.instance.Add(t);
        }
        else
        {
            EquipmentManager.instance.Equip(t);
        }
    }
}
