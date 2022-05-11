using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancingManager : MonoBehaviour
{
    public int intcomputeClick(Trinket t)
    {
        float multiplier;

        multiplier = rarityComputing(t);
        

        if(t.trinketSlot == TrinketSlot.Lantern)
        { 
        multiplier += 0.05f;
        }

        return (int)Mathf.Ceil(t.clickMod * multiplier);

    
    
    }

    public int intcomputeCrit(Trinket t)
    {
        float multiplier;

        multiplier = rarityComputing(t);


        if (t.trinketSlot == TrinketSlot.Oar)
        {
            multiplier += 0.05f;
        }

        return (int)Mathf.Ceil(t.critMod * multiplier);



    }

    public int intcomputeAuto(Trinket t)
    {
        float multiplier;

        multiplier = rarityComputing(t);


        if (t.trinketSlot == TrinketSlot.Hood)
        {
            multiplier += 0.05f;
        }

        return (int)Mathf.Ceil(t.autoMod * multiplier);



    }

    public int computeCost(Trinket t)
    {
        int multiplier = 0;
        switch (t.rarity)
        {
            case Rarity.Common:

                multiplier = 10;

                break;

            case Rarity.Rare:

                multiplier = 12;

                break;

            case Rarity.Calming:

                multiplier = 15;

                break;

            case Rarity.Melancolic:

                multiplier = 25;

                break;

            case Rarity.Ghostly:

                multiplier = 40;

                break;

        }

        int res = t.level * t.level * t.level;
        res += multiplier * multiplier * t.level /100;
        t.level += 1;
        return res;
    }


    public void update(Trinket t)
    {
        t.clickMod = intcomputeClick(t);
        t.critMod = intcomputeCrit(t);
        t.autoMod = intcomputeAuto(t);
    }

    public float rarityComputing(Trinket t)
    {
        float multiplier = 0;

        switch (t.rarity)
        {
            case Rarity.Common:

                multiplier = 1.05f;

                break;

            case Rarity.Rare:

                multiplier = 1.10f;

                break;

            case Rarity.Calming:

                multiplier = 1.15f;

                break;

            case Rarity.Melancolic:

                multiplier = 1.20f;

                break;

            case Rarity.Ghostly:

                multiplier = 1.25f;

                break;

        }
        return multiplier;
    }
}
