using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }



    public List<Trinket> trinkets = new List<Trinket>();
    public List<LostSoul> souls = new List<LostSoul>();

    public void Add(Trinket t)
    {
        trinkets.Add(t);


    }

    public void Remove(Trinket t)
    {
        trinkets.Remove(t);


    }

    public void AddSoul(LostSoul l)
    {
        souls.Add(l);


    }

    public void RemoveSoul(LostSoul l)
    {
        souls.Remove(l);

    }
}
