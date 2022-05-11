using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectWindow : MonoBehaviour
{
    public LostSoul soul;

    public Text statement;
    public Text loot;

    public Image icon;

    public void getReward()
    {
        switch (soul.type)
        {
            case Type.Ectoplasm:
                PointsManager.points += soul.quantity;
                break;

            case Type.Soul:
                
                PointsManager.soulFragments += soul.quantity;
                break;

            case Type.Trinket:
                
                PointsManager.trinketEssence += soul.quantity;
                break;

        }
        PlayerPrefs.SetInt(soul.pName + "timerOn", 0);
        this.gameObject.SetActive(false);
    }
}
