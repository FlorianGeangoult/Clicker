using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static int points;
    public static float critChance;
    public static float multiplier = 1;
    public static int soulFragments = 0;
    public static int trinketEssence = 10000;
    

    public List<int> pointsTrinketMods = new List<int>();
    public static List<float> critChanceMods = new List<float>();

    public AnimManager am;

    public Data d;

    public Text t;
    public Text SFt;

    void Awake()
    {
        
        points = PlayerPrefs.GetInt("Points");
        points = 800;
        soulFragments = 800;
        multiplier = PlayerPrefs.GetFloat("Multiplier");
        if(multiplier == 0)
        {
            multiplier = 1;
        }
    }

    public void reset()
    {
        PlayerPrefs.DeleteAll();
    }

    public void addPoint()
    {
       
        int temp = computePointPerClick();
        foreach(int i in pointsTrinketMods)
        {
            temp += i;
        }
        if (critChance != 0)
        {
            if (rollCrit())
            {
                temp = temp * 2;
            }
        }
        points += temp;
        am.spawnPopup(Instantiate(am.ectoPopup, Input.mousePosition, Quaternion.identity, am.UI.gameObject.transform), temp);

    }

    public static int computePointPerClick()
    {
        Debug.Log(multiplier);

        int res = (int)Mathf.Ceil(multiplier);
        
        return res;
    }

    public static bool rollCrit()
    {
        float temp = UnityEngine.Random.Range(0.0f, 1000.0f);

        float crit = critChance;

        foreach (float f in critChanceMods)
        {
            crit += f;
            Debug.Log("crit : " + crit + " temp : " + temp);
        }

        if (temp <= crit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void addTrinketMods(Trinket t)
    {
        if(t.clickMod != 0)
        {
            this.pointsTrinketMods.Add(t.clickMod);
        }

        if (t.critMod != 0)
        {
            Debug.Log("ohfeoiqgz^b^qzhegôq");
            critChanceMods.Add(t.critMod);
        }

    }

    public void RemoveTrinketMods(Trinket t)
    {
        if (t.clickMod != 0)
        {
            this.pointsTrinketMods.Remove(t.clickMod);
        }

        if (t.critMod != 0)
        {
            critChanceMods.Remove(t.critMod);
        }

    }

    // Update is called once per frame
    void Update()
    {
        t.text = points.ToString();
        SFt.text = soulFragments.ToString();
    }

    void OnApplicationQuit()
    {
        Debug.Log("Quitting");
        PlayerPrefs.SetInt("Points", points);
        PlayerPrefs.SetFloat("Multiplier", multiplier);
        Debug.Log(DateTime.Now);
        PlayerPrefs.SetString("OfflineTime", DateTime.Now.ToBinary().ToString());
        reset();
    }
}
