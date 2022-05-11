using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    public static float modifier = 1;
    public bool isPoint = false;

    public static List<float> autoPointMods = new List<float>();

    public static AutoClicker Instance;

    void Update()
    {
        if(!isPoint)
        {
        isPoint = true;
        StartCoroutine(AutoPoint());
        }
    }


    IEnumerator AutoPoint()
    {

        
    
    yield return new WaitForSeconds(SecsPerPoint());
    PointsManager.points += 1;
    isPoint = false;
    }

    public static float PointsPerSec()
    {
        return 1 / SecsPerPoint();
    }

    public static void addTrinketMods(Trinket t)
    {
        if (t.autoMod != 0)
        {
            autoPointMods.Add(t.clickMod);
        }


    }

    public static void RemoveTrinketMods(Trinket t)
    {
        if (t.autoMod != 0)
        {
            autoPointMods.Remove(t.clickMod);
        }


    }

    public static float SecsPerPoint()
    {
        float temp = modifier;
        foreach (float i in autoPointMods)
        {
            temp += i;
        }
      

        return 1000 / temp;
    }
}
