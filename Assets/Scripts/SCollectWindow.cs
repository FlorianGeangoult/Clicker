using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCollectWindow : MonoBehaviour
{
    public ShopType stype;

    public GameObject trinketReward;
    public GameObject soulReward;
    public GameObject fragReward;

    public Text statement;
    public Text loot;

    public Text trinketCrit;
    public Text trinketEcto;
    public Text trinketAuto;

    public Text soulOldLvl;
    public Text soulNewLvl;
    public Text soulNew;
    public Text soulName;

    public Image iconTrinket;
    public Image iconSoul;

    public void getReward()
    {
       
                soulReward.SetActive(false);
                trinketReward.SetActive(false);
                fragReward.SetActive(false);

        MenuManager.isMenuClickable = true;
        InventoryUI.instance.shopGroup.interactable = true;
        this.gameObject.SetActive(false);
    }

    public void getReward(int qty)
    {
        soulReward.SetActive(false);
        trinketReward.SetActive(false);
        fragReward.SetActive(false);

        MenuManager.isMenuClickable = true;
        InventoryUI.instance.shopGroup.interactable = true;
        this.gameObject.SetActive(false);
    }
}
