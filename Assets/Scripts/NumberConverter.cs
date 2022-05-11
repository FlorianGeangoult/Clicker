using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberConverter : MonoBehaviour
{
    public static NumberConverter instance;
    public char[] letters;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

        letters = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    }

    public string ConvertPoints(int points)
    {
        int i =0;
        string s = "";
        int p = points;
        while(p / 1000 > 999)
        {
            p = p / 1000;
            i += 1;
            s = p.ToString() + letters[i - 1];
        }

        if (i == 0)
        {
            return p.ToString();
        }
        else
        {
            return s;
        }
        
    }
}
