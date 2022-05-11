using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSoul", menuName = "Lost Soul")]
public class LostSoul : ScriptableObject
{
    public int level;

    public SoulWindow sw;

    public Type type;

    public Sprite icon;

    public int quantity;

    public string description;
    public string pName;

    public float initWaitingTime;
    public float waitingTime;
}

[System.Serializable]
public enum Type { Ectoplasm, Soul, Trinket}
