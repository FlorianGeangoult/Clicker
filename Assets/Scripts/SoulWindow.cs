using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulWindow : MonoBehaviour
{
    public float msToWait;
    public Text timer;
    public Button soulButton;
    public Button collectButton;
    private long lastSoulOpen;

    public LostSoul soul;

    public Text pName;
    public Text lvlText;
    public Text description;

    private InventoryUI ui;

    public Image spriteHolder;


    void Start()
    {
        ui = InventoryUI.instance;
    }


    // Start is called before the first frame update
    public void SetUp(LostSoul l)
    {
        this.soul = l;
        msToWait = this.soul.waitingTime;
        pName.text = this.soul.pName;
        lvlText.text = this.soul.level.ToString();
        description.text = this.soul.description;
        Debug.Log(PlayerPrefs.GetString(this.soul.pName + "LastSoulOpen"));
        this.soul.sw = this;
        if (PlayerPrefs.HasKey(this.soul.pName + "LastSoulOpen"))
        {
            
            lastSoulOpen = Convert.ToInt64(PlayerPrefs.GetString(this.soul.pName + "LastSoulOpen"));
        }
        else
        {
            
            lastSoulOpen = 0;
        }
       

        if (!IsSoulReady())
        {
            soulButton.gameObject.SetActive(false);
            collectButton.gameObject.SetActive(false);
        }
        if (IsSoulReady() && PlayerPrefs.GetInt(this.soul.pName + "timerOn") == 1)
        {
            collectButton.gameObject.SetActive(true);
            soulButton.gameObject.SetActive(false);
        }
        if(IsSoulReady() && PlayerPrefs.GetInt(this.soul.pName + "timerOn") != 1)
        {
            collectButton.gameObject.SetActive(false);
            soulButton.gameObject.SetActive(true);
        }
    }

    public void collect()
    {
        ui.showCollectWindow(this.soul, this.soul.quantity);
    }

    public void updateContent()
    {
        lvlText.text = this.soul.level.ToString();
        msToWait = this.soul.waitingTime;
    }
    

   

    // Update is called once per frame
    void Update()
    {
        if(!soulButton.gameObject.activeSelf)
        {
            if(IsSoulReady())
            {
                if (PlayerPrefs.GetInt(this.soul.pName + "timerOn") != 1)
                {
                    soulButton.gameObject.SetActive(true);
                    collectButton.gameObject.SetActive(false);
                    return;
                }
                else
                {
                    soulButton.gameObject.SetActive(false);
                    collectButton.gameObject.SetActive(true);
                    return;
                }
            }

            var oldTime = DateTime.FromBinary(lastSoulOpen);
            var currentTime = DateTime.Now;
            TimeSpan difference = currentTime.Subtract(oldTime);
            var m = (float)difference.TotalSeconds;
            float secondsLeft = (float)(msToWait - m);

            string r = " ";

            r += ((int)secondsLeft / 3600).ToString() + "h ";
            secondsLeft -= ((int)secondsLeft / 3600) * 3600;

            r += ((int)secondsLeft / 60).ToString("00") + "m ";

            r += (secondsLeft % 60).ToString("00") + "s";
            timer.text = r;


        }
        

    }

    public void SoulsClick()
    {

        lastSoulOpen = (long)DateTime.Now.ToBinary();
        
        PlayerPrefs.SetString(this.soul.pName + "LastSoulOpen", lastSoulOpen.ToString());
        PlayerPrefs.SetInt(this.soul.pName + "timerOn", 1);
        
        soulButton.gameObject.SetActive(false);
    }

    private bool IsSoulReady()
    {
        
        var oldTime = DateTime.FromBinary(lastSoulOpen);
        var currentTime = DateTime.Now;
        TimeSpan difference = currentTime.Subtract(oldTime);
        var m = (float)difference.TotalSeconds;
        float secondsLeft = (float)(msToWait - m);


        if (secondsLeft < 0)
            return true;

        return false;
    }


}
