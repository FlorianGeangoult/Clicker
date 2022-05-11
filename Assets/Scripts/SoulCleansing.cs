using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulCleansing : MonoBehaviour
{

    public Text reward;

    public Data gameData;

    public int soulCleansingReward()
    {
        int temp = gameData.getTotalLvl();

        int temp2 = (int)Mathf.Ceil(PointsManager.points / 10000);

        return temp + temp2;

    }

    void Update()
    {
        this.reward.text ="+ " +  soulCleansingReward().ToString();
    }

    public void soulCleanse()
    {
        PointsManager.soulFragments += soulCleansingReward();
        gameData.clearPoints();
        gameData.clearUpgrades();

        

    }



}
