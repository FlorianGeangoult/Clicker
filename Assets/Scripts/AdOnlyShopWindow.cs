using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdOnlyShopWindow : ShopWindowMaster
{









    // Start is called before the first frame update
    public void SetUp()
    {



        if (!IsShopReady())
        {
            shopButton.gameObject.SetActive(false);

        }
        if (IsShopReady())
        {

            shopButton.gameObject.SetActive(true);
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



            var oldTime = DateTime.FromBinary(lastShopOpen);
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

    public void ShopClick()
    {
        AdManager.instance.PlayAd(OnRewardedAdSuccess);
       
    }

    void OnRewardedAdSuccess()
    {
        ui.showSCollectWindow(this.type, this);
        lastShopOpen = (long)DateTime.Now.ToBinary();

        PlayerPrefs.SetString("Shop element : " + this.id, lastShopOpen.ToString());

        Debug.Log("ok");
        shopButton.gameObject.SetActive(false);
    }

    
    
}
