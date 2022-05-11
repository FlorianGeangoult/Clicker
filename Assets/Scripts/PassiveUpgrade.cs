using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveUpgrade : Upgrade
{
    public GameObject ac;
    public GameObject acInstance;
    public GameObject nextMem;

    public bool isChoiceMemory;

    void Awake()
    {
    
        this.lvl = PlayerPrefs.GetInt(this.nameString);
      
        if (this.lvl != 0)
        {
            if (!acInstance)
            {
                activateAutoclick();
            }

            if (nextMem != null)
            {
                MenuManager.addMemory(this.nextMem);
            }

            if(isChoiceMemory)
            {

                MenuManager.instance.choiceButton.gameObject.SetActive(true);

            }

            this.statValue = PlayerPrefs.GetFloat(this.nameString + " value : ");
            applyEffect();
            updateDescr();


        }
        
        this.setCost(this.lvl);
    }


   
   

    public override void purchase()
    {
    
        this.lvl += 1;
        PlayerPrefs.SetInt(this.nameString, this.lvl);
        
        if (!acInstance)
        {
            activateAutoclick();
        }
        if (this.lvl == 1)
        {


            if (nextMem != null)
            {
                MenuManager.addMemory(this.nextMem);
                DialogueTrigger trigger = FindObjectOfType<DialogueTrigger>();
                trigger.dialogue = Data.getCorrespondingDialogue(this.gameObject);
                trigger.TriggerDialogue();
            }
            if(isChoiceMemory)
            {
                MenuManager.instance.choiceButton.gameObject.SetActive(true);
                PlayerPrefs.SetInt("Choix affiché : ", 1);

            }
        }
        e.lvlText.text = "Lvl. " + this.lvl.ToString();
        //PlayerPrefs.SetInt(e.upName.ToString(), this.lvl);
        PointsManager.points -= this.pointCost;

        setCost(this.lvl);
        updateEffect();
        applyEffect();
        updateDescr();



    }

    public void activateAutoclick()
    {
       acInstance =  Instantiate(ac);
    }

    public override void getValue()
    {
        this.statValue = AutoClicker.modifier;

    }


    public override void applyEffect()
    {

        AutoClicker.modifier = this.statValue;

    }

    public override void updateDescr()
    {
        e.description.text = "You extract " + AutoClicker.PointsPerSec() + " Ectoplasm every second";
    }
}
