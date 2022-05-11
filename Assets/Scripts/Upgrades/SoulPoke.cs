using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPoke : Upgrade
{
    public override void getValue()
    {
        this.statValue = PointsManager.multiplier;

    }


    public override void applyEffect()
    {
    PointsManager.multiplier = this.statValue;

    }

    public override void updateDescr()
    {
    e.description.text = "Your poke extracts " + PointsManager.computePointPerClick() + " Ectoplasm";
    }

}
