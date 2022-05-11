using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MementoMori : Upgrade
{
    public override void getValue()
    {
        this.statValue = PointsManager.critChance;

    }


    public override void applyEffect()
    {
        if(this.statValue == 0)
        {
            this.statValue = 1.0f;
        }
        PointsManager.critChance = this.statValue;

    }

    public override void updateDescr()
    {
        e.description.text = "Your poke has " + PointsManager.critChance/10 + "% chance to extract double Ectoplasm";
    }
}
