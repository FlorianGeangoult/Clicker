using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{

    public static List<GameObject> memoriesInstances = new List<GameObject>();

    public static Ghost currentGhost;
    public List<Ghost> ghosts;


    


    public List<Upgrade> upgrades = new List<Upgrade>();
    public List<PassiveUpgrade> memories = new List<PassiveUpgrade>();

    public Sprite ghostHurtS;

    public Button clicker;
    public static Data instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        //currentGhost = ghosts[PlayerPrefs.GetInt("Ghost")];
        currentGhost = ghosts[0];
        Debug.Log(currentGhost.ToString());
        Debug.Log(currentGhost.upgrades[0].ToString());
        MenuManager.addMemory(currentGhost.upgrades[0]);
        for (int i = 0; i < PlayerPrefs.GetInt("Number of Trinkets"); i++)
        {
            int r = PlayerPrefs.GetInt("Trinket Rarity : " + i);
            int t = PlayerPrefs.GetInt("Trinket Slot : " + i);
            int clM = PlayerPrefs.GetInt("Trinket clickMod : " + i);
            int crM = PlayerPrefs.GetInt("Trinket critMod : " + i);
            int aM = PlayerPrefs.GetInt("Trinket autoMod : " + i);
            ItemSpawner.instance.GenerateTrinketFromData(r, t, clM, crM, aM, false);
        }

        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetInt("Trinket Equipped : " + i) == 1)
            {
                int r = PlayerPrefs.GetInt("Equipped Trinket Rarity : " + i);
                int t = PlayerPrefs.GetInt("Equipped Trinket Slot : " + i);
                int clM = PlayerPrefs.GetInt("Equipped Trinket clickMod : " + i);
                int crM = PlayerPrefs.GetInt("Equipped Trinket critMod : " + i);
                int aM = PlayerPrefs.GetInt("Equipped Trinket autoMod : " + i);
                ItemSpawner.instance.GenerateTrinketFromData(r, t, clM, crM, aM, true);
            }
        }

    }

    public void nextGhost()
    {
        
        currentGhost = ghosts[ghosts.IndexOf(currentGhost) + 1];
        clearUpgrades();
       
    }

    public static DialoguePortion getCorrespondingDialogue(GameObject m)
    {
        
        return currentGhost.dialogues[memoriesInstances.IndexOf(m)];
    }


    public void clearPoints()
    {
        PlayerPrefs.SetInt("Points", 0);
        PointsManager.points = 0;
    }

    public void clearUpgrades()
    {
        foreach(Upgrade u in upgrades)
        {
            u.reset();
        }

        foreach(GameObject p in memoriesInstances)
        {
            p.GetComponentInChildren<PassiveUpgrade>().reset();
            Destroy(p);
        }
        memoriesInstances.Clear();

        MenuManager.addMemory(currentGhost.upgrades[0]);
    }

    public int getTotalLvl()
    {
        int res = 0;
        foreach (Upgrade u in upgrades)
        {
            res += u.lvl;
        }

        foreach (GameObject p in memoriesInstances)
        {
            res += p.GetComponentInChildren<PassiveUpgrade>().lvl;
        }
        return res;
    }




    void OnApplicationQuit()
    {
        SaveData();
        
        
    }


    public void SaveData()
    {
        Debug.Log("Quitting");
        PlayerPrefs.SetInt("Ghost", ghosts.IndexOf(currentGhost));
        
        //SaveUpgrades();
        SaveTrinkets();
        SavePets();
        SavePoints();
    }

    public void SaveUpgrades()
    {

    }

    public void SavePoints()
    {
        
        PlayerPrefs.SetInt("Points", PointsManager.points);
        PlayerPrefs.SetFloat("Multiplier", PointsManager.multiplier);
        PlayerPrefs.SetFloat("critChance", PointsManager.critChance);
        PlayerPrefs.SetInt("soulFragments", PointsManager.soulFragments);
        PlayerPrefs.SetInt("trinketEssence", PointsManager.trinketEssence);
    
        Debug.Log(DateTime.Now);
        PlayerPrefs.SetString("OfflineTime", DateTime.Now.ToBinary().ToString());
    }

    public void SaveTrinkets()
    {
        int trinketsNumber = Inventory.instance.trinkets.Count;
        for (int i = 0; i < trinketsNumber; i++)
        {
            PlayerPrefs.SetInt("Trinket Rarity : " + i, (int)Inventory.instance.trinkets[i].rarity);
            PlayerPrefs.SetInt("Trinket Slot : " + i, (int)Inventory.instance.trinkets[i].trinketSlot);
            PlayerPrefs.SetInt("Trinket clickMod : " + i, (int)Inventory.instance.trinkets[i].clickMod);
            PlayerPrefs.SetInt("Trinket critMod : " + i, (int)Inventory.instance.trinkets[i].critMod);
            PlayerPrefs.SetInt("Trinket autoMod : " + i, (int)Inventory.instance.trinkets[i].autoMod);
        }
        PlayerPrefs.SetInt("Number of Trinkets", trinketsNumber);

        for (int i = 0; i < 3; i++)
        {
            
            if (EquipmentManager.instance.trinkets[i] != null)
            {
                
                Debug.Log("rentre dans la boucle d'équipement" + EquipmentManager.instance.trinkets[i] + " " + EquipmentManager.instance.trinkets[i].trinketSlot);
                PlayerPrefs.SetInt("Trinket Equipped : " + i, 1);
                PlayerPrefs.SetInt("Equipped Trinket Rarity : " + i, (int)EquipmentManager.instance.trinkets[i].rarity);
                PlayerPrefs.SetInt("Equipped Trinket Slot : " + i, (int)EquipmentManager.instance.trinkets[i].trinketSlot);
                PlayerPrefs.SetInt("Equipped Trinket clickMod : " + i, (int)EquipmentManager.instance.trinkets[i].clickMod);
                PlayerPrefs.SetInt("Equipped Trinket critMod : " + i, (int)EquipmentManager.instance.trinkets[i].critMod);
                PlayerPrefs.SetInt("Equipped Trinket autoMod : " + i, (int)EquipmentManager.instance.trinkets[i].autoMod);
            }
            else
            {
                PlayerPrefs.SetInt("Trinket Equipped : " + i, 0);
            }
        }


    }

    public void SavePets()
    {
        int soulsNumber = Inventory.instance.souls.Count;
        for(int i = 0; i< soulsNumber; i++)
        {
            PlayerPrefs.SetString("Lost Soul Name : " + i, Inventory.instance.souls[i].pName);
            Debug.Log("Lost Soul Name : " + PlayerPrefs.GetString("Lost Soul Name : " + i));
            PlayerPrefs.SetInt("Lost Soul Level : " + i, Inventory.instance.souls[i].level);
            Debug.Log("Lost Soul Level : " + PlayerPrefs.GetInt("Lost Soul Level : " + i));
        }
        PlayerPrefs.SetInt("Number of Lost Souls", soulsNumber);
    }
}
