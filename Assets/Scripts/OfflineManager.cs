using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class OfflineManager : MonoBehaviour

{
    public GameObject offlineWindow;
    public Text text;
    

    // Start is called before the first frame update
    void Start()
    {
        loadOfflinePoints();
    }

    

    public void loadOfflinePoints()
    {
        if (PlayerPrefs.HasKey("OfflineTime"))
        {
            long tempOfflineTime = Convert.ToInt64(PlayerPrefs.GetString("OfflineTime"));
            var oldTime = DateTime.FromBinary(tempOfflineTime);
            Debug.Log(oldTime);
            var currentTime = DateTime.Now;
            Debug.Log(currentTime);
            TimeSpan difference = currentTime.Subtract(oldTime);
            Debug.Log(difference);
            var offlineTime = (float)difference.TotalSeconds;

            int pointsCollected = (int)Mathf.Ceil(AutoClicker.PointsPerSec() * offlineTime);
            if (pointsCollected != 0)
            {
                offlineWindow.SetActive(true);
                text.text = "+ " + pointsCollected.ToString();
            }
            PointsManager.points += pointsCollected;
        }
    }
}
