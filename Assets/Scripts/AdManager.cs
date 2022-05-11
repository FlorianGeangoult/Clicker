using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    Action onRewardedAdSuccess;

    public static AdManager instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Start()
    {
        Advertisement.Initialize("4730671");
        Advertisement.AddListener(this);
    }

    public void PlayAd(Action onSuccess)
    {
        onRewardedAdSuccess = onSuccess;
        if(Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else
        {
            Debug.Log("not ready");
        }
    }

    public void fart()
    {

    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("bwyusdyuc je hais ma vie");
        if(placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {
            Debug.Log("bwyusdyuc je hais ma vie ?");
            onRewardedAdSuccess.Invoke();
        }
    }
}
