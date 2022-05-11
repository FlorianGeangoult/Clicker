using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : ShopWindowMaster
{
    
    public float adMsToWait;
    
    public Text adTimer;
    
    public Button adShopButton;
    
    private long lastShopOpenAd;

    

    

   





    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("SETUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUP");
        ui = InventoryUI.instance;

        if (!IsShopReady())
        {
            shopButton.gameObject.SetActive(false);
            
        }
        if (IsShopReady())
        {
            
            shopButton.gameObject.SetActive(true);
        }
        if (!IsAdShopReady())
        {
            adShopButton.gameObject.SetActive(false);

        }
        if (IsAdShopReady())
        {

            adShopButton.gameObject.SetActive(true);
        }

    }

    



    // Update is called once per frame
    void Update()
    {
        if (!shopButton.gameObject.activeSelf)
        {
            if (IsShopReady())
            {
                shopButton.gameObject.SetActive(true);
            }
            else
            {
                shopButton.gameObject.SetActive(false);
            }

           

            var oldTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("Shop element : " + this.id)));
            
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
        if(!adShopButton.gameObject.activeSelf)
        {

            if (IsAdShopReady())
            {
                adShopButton.gameObject.SetActive(true);
            }
            else
            {
                adShopButton.gameObject.SetActive(false);
            }

            var adoldTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("Shop element ad: " + this.id)));
           
            var adcurrentTime = DateTime.Now;
            TimeSpan addifference = adcurrentTime.Subtract(adoldTime);
            var adm = (float)addifference.TotalSeconds;
            float adsecondsLeft = (float)(adMsToWait - adm);

            string adr = " ";

            adr += ((int)adsecondsLeft / 3600).ToString() + "h ";
            adsecondsLeft -= ((int)adsecondsLeft / 3600) * 3600;

            adr += ((int)adsecondsLeft / 60).ToString("00") + "m ";

            adr += (adsecondsLeft % 60).ToString("00") + "s";
            adTimer.text = adr;

        }


    }

    public void ShopClick()
    {
        ui.showSCollectWindow(this.type, this);
        lastShopOpen = (long)DateTime.Now.ToBinary();

        PlayerPrefs.SetString("Shop element : " + this.id , lastShopOpen.ToString());
        
        Debug.Log("ok");
        shopButton.gameObject.SetActive(false);
    }

    public void adShopClick()
    {
        AdManager.instance.PlayAd(OnRewardedAdSuccess);
        ui.showSCollectWindow(this.type, this);
        lastShopOpenAd = (long)DateTime.Now.ToBinary();

        PlayerPrefs.SetString("Shop element ad: " + this.id, lastShopOpenAd.ToString());
        
        Debug.Log("ok");
        adShopButton.gameObject.SetActive(false);
    }

    
    

void OnRewardedAdSuccess()
{
        ui.showSCollectWindow(this.type, this);
        lastShopOpenAd = (long)DateTime.Now.ToBinary();

        PlayerPrefs.SetString("Shop element ad: " + this.id, lastShopOpenAd.ToString());

        Debug.Log("ok");
        adShopButton.gameObject.SetActive(false);
    }

private bool IsAdShopReady()
    {
        if (PlayerPrefs.HasKey("Shop element ad: " + this.id))
        {
            var oldTime = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("Shop element ad: " + this.id)));
            var currentTime = DateTime.Now;
            TimeSpan difference = currentTime.Subtract(oldTime);
            var m = (float)difference.TotalSeconds;
            float secondsLeft = (float)(adMsToWait - m);


            if (secondsLeft < 0)
                return true;

            return false;
        }
        else
        {
            return true;
        }
    }
}


