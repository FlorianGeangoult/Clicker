using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform items;
    public GameObject slotPrefab;

    public Transform petsWindow;
    public GameObject pets;

    public TrinketSlot currentSlot;

   public Inventory inventory;

    public GameObject equippedWindow;
    public GameObject trinketWindow;
    public GameObject enhancingWindow;

    public TrinketWindow tw;
    public EquippedWindow ew;
    public EnhancingWindow enw;


    public CollectWindow cw;
    public GameObject collectWindow;

    public GameObject shopTrinketWindow;
    public GameObject shopSoulWindow;
    public GameObject shopFragmentWindow;

    public SCollectWindow scw;
    public GameObject scollectWindow;

    public CanvasGroup shopGroup;


    public Sprite ectoplasm;
    public Sprite soulfragment;
    public Sprite trinketessence;


    public List<InventorySlot> slots = new List<InventorySlot>();
    public List<SoulWindow> souls = new List<SoulWindow>();


    public static InventoryUI instance;

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
        inventory = Inventory.instance;
        currentSlot = TrinketSlot.None;
        UpdateUI(TrinketSlot.Lantern);
        instantiateSouls();
        //inventory.onTrinketChangedCallback += UpdateUI;

        
    }

    public void SelectUI(TrinketSlotChoice slotC)
    {
        UpdateUI(slotC.slot);
    }

    public void showEnhancedWindow(InventorySlot i)
    {
        enhancingWindow.SetActive(true);
        trinketWindow.SetActive(false);
        equippedWindow.SetActive(false);
        enw.SetUp(i);

    }


    public void showTrinketWindow(InventorySlot i)
    {
        trinketWindow.SetActive(true);
        enhancingWindow.SetActive(false);
        tw.SetUp(i);

    }

    public void showEquipmentWindow(EquipmentSlot e)
    {
        if (e.trinket != null)
        {
            enhancingWindow.SetActive(false);
            equippedWindow.SetActive(true);
            ew.SetUp(e);
        }
    }

    public void UpdateUI(TrinketSlot slot)
    {
        Debug.Log("j'essaie d'update : " + slot);
        
            currentSlot = slot;
            foreach(InventorySlot s in slots)
            {
                s.DestroySlot();
            
            }
            slots.Clear();

            foreach (Trinket t in inventory.trinkets)
            {
                
                if (t.trinketSlot == slot)
                {
                  
                    InventorySlot temp = Instantiate(slotPrefab, items).GetComponentInChildren<InventorySlot>();
                    slots.Add(temp);
                    temp.AddTrinket(t);
                }
                
            }
        
    }

    public void instantiateSouls()
    {
        for(int i = 0; i< PlayerPrefs.GetInt("Number of Lost Souls"); i++)
        {
            LostSoul lostSoul = null;
            foreach (LostSoul ls in ItemSpawner.instance.souls)
            {
                if(PlayerPrefs.GetString("Lost Soul Name : " + i) == ls.pName)
                {
                    lostSoul = ls;
                }
            }
            lostSoul.level = PlayerPrefs.GetInt("Lost Soul Level : " + i);
            Inventory.instance.AddSoul(lostSoul);
        }
        foreach (LostSoul l in inventory.souls)
        {
           
                SoulWindow temp = Instantiate(pets, petsWindow).GetComponentInChildren<SoulWindow>();
                souls.Add(temp);
                temp.SetUp(l);

        }


    }

    public void UpdateSouls()
    {
        
        

        foreach (LostSoul l  in inventory.souls)
        {

            bool isAlreadyInstantiated = false;
            foreach (SoulWindow s in souls)
            {
               
                if (l.pName == s.soul.pName)
                {
                    isAlreadyInstantiated = true;
                    
                }
            }
            if(!isAlreadyInstantiated)
            {
               
                SoulWindow temp = Instantiate(pets, petsWindow).GetComponentInChildren<SoulWindow>();
                souls.Add(temp);
                temp.SetUp(l);
            }

        }
    }

   

    public void showCollectWindow(LostSoul l, int i)
    {
        collectWindow.SetActive(true);
        cw.statement.text = l.pName + " has brought you something from the depths...";
        string amount = "+ " + i.ToString();
        switch(l.type)
        {
            case Type.Ectoplasm:
                amount += " Ectoplasm";
                cw.icon.sprite = ectoplasm;
                break;

            case Type.Soul:
                amount += " Soul Fragments";
                cw.icon.sprite = soulfragment;
                break;

            case Type.Trinket:
                amount += " Trinket Essence";
                cw.icon.sprite = trinketessence;
                break;

        }

        cw.soul = l;
        cw.loot.text = amount;
        
        

    }

    public void showSCollectWindow(ShopType type, ShopWindowMaster shopw)
    {
        scollectWindow.SetActive(true);
        //scw.statement.text = l.pName + " has brought you something from the depths...";
        //string amount = "+ " + i.ToString();
        switch (type)
        {
            case ShopType.LostSoul:
                LostSoul ls = ItemSpawner.instance.generateLostSoul();
                shopSoulWindow.SetActive(true);
                shopGroup.interactable = false;
                scw.iconSoul.sprite = ls.icon;
                scw.soulName.text = ls.pName;
                
                if(ls.level> 1)
                {

                    scw.soulNew.gameObject.SetActive(false);
                    scw.soulNewLvl.gameObject.SetActive(true);
                    scw.soulNewLvl.text = ls.level.ToString();
                    int oldLvl = ls.level - 1;
                    scw.soulOldLvl.text = oldLvl.ToString();
                }
                else
                {
                    scw.soulNew.gameObject.SetActive(true);
                    scw.soulNewLvl.gameObject.SetActive(false);
                    scw.soulOldLvl.text = ls.level.ToString();

                }
                break;

            case ShopType.Trinket:
                Trinket t = ItemSpawner.instance.createRandomItem();
                shopTrinketWindow.SetActive(true);
                shopGroup.interactable = false;
                scw.iconTrinket.sprite = t.icon;
                scw.trinketCrit.text = t.critMod.ToString() + " Crit chance";
                scw.trinketEcto.text = t.clickMod.ToString() + " Ectoplasm per tap";
                scw.trinketAuto.text = t.autoMod.ToString() + " Auto collect";
                MenuManager.isMenuClickable = false;
                break;

            case ShopType.SoulFragment:
                shopFragmentWindow.SetActive(true);
                PointsManager.soulFragments += 50;
                shopGroup.interactable = false;
                
                break;

        }

        //scw.soul = l;
        //scw.loot.text = amount;



    }




}
