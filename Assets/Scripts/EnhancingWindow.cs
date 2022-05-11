using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhancingWindow : InventoryWindow
{
    public Text enhancedStat1;
    public Text enhancedStat2;
    public Text enhancedStat3;

    public Text essenceCost;

    public InventorySlot slot;

    public EnhancingManager em;

    public void SetUp(InventorySlot s)
    {
        this.slot = s;

        this.icon.sprite = this.slot.trinket.icon;

        this.tname.text = this.slot.trinket.trinketName;

        this.statbuff1.text = this.slot.trinket.clickMod.ToString();
        this.statbuff2.text = this.slot.trinket.critMod.ToString();
        this.statbuff3.text = this.slot.trinket.autoMod.ToString();

        this.enhancedStat1.text = this.em.intcomputeClick(this.slot.trinket).ToString();
        Debug.Log(this.em.intcomputeClick(this.slot.trinket).ToString());
        this.enhancedStat2.text = this.em.intcomputeCrit(this.slot.trinket).ToString();
        this.enhancedStat3.text = this.em.intcomputeAuto(this.slot.trinket).ToString();

        this.essenceCost.text = this.em.computeCost(this.slot.trinket).ToString();

    }


    public void Enhance()
    {
        if (PointsManager.trinketEssence > this.em.computeCost(this.slot.trinket))
        {
            this.em.update(this.slot.trinket);
            SetUp(this.slot);
        }
    }
}
