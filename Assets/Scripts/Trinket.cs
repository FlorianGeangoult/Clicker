using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NewTrinket", menuName = "Trinket")]
public class Trinket : ScriptableObject
{

    public int clickMod;
    public float critMod;
    public float autoMod;

    public int level;


    public Sprite icon;
    public string trinketName;


    public TrinketSlot trinketSlot;
    public Rarity rarity;



}

[System.Serializable]
public enum TrinketSlot { Lantern, Hood, Oar, None}

[System.Serializable]
public enum Rarity { Common, Rare, Calming, Melancolic, Ghostly }
