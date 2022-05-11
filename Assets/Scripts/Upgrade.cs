using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade : MonoBehaviour
{


    public string nameString;
    public int lvl = 0;
    public float statValue;
    public float modifier;
    public int initPointCost;
    public int pointCost;
    public float pointModifier;

    public Sprite icon;
    

    public shopElement e;


    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("this lvl : " + PlayerPrefs.GetInt(e.upName.ToString()));


        this.lvl = PlayerPrefs.GetInt(e.upName.ToString());
        Debug.Log("this lvl : " + this.lvl);

        setCost(this.lvl);

        if (this.lvl != 0)
        {
            this.statValue = PlayerPrefs.GetFloat(this.nameString + " value : ");
            applyEffect();
            updateDescr();

        }

    }
    

    void Update()
    {
        if(this.pointCost > PointsManager.points)
        {
            e.buyButton.interactable = false;
        }
        else
        {
            e.buyButton.interactable = true;
        }
    }

    void Start()
    {
        getValue();
        updateDescr();
        e.upName.text = this.nameString;
        e.lvlText.text = "Lvl. " + this.lvl.ToString();
        e.spriteHolder.sprite = this.icon;
    }

    public virtual void purchase()
    {
        this.lvl += 1;
        e.lvlText.text = "Lvl. " + this.lvl.ToString();
        PlayerPrefs.SetInt(e.upName.ToString(), this.lvl);
        PointsManager.points -= this.pointCost;

        setCost(this.lvl);
        updateEffect();
        applyEffect();
        updateDescr();
        


    }

    public void setCost(int lvl)
    {
        int temp = initPointCost;
        for(int i = 0; i<lvl; i++)
        {
            Debug.Log(temp + " " + this.pointModifier);
            temp = (int)Mathf.Ceil(temp * this.pointModifier);
        }
        this.pointCost = temp;
        updateCoinCost();
    }

    public void reset()
    {
        this.lvl = 0;
        this.setCost(this.lvl);
    }


    public void updateCoinCost()
    {
        
        
        e.pointsText.text = this.pointCost.ToString();
    }

    public void updateEffect()
    {
        this.statValue = this.statValue * this.modifier;
        PlayerPrefs.SetFloat(this.nameString + " value : ", this.statValue);
    }


    public abstract void getValue();

    public abstract void applyEffect();

    public abstract void updateDescr();
}
