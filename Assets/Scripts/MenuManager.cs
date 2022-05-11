using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject currentContent;
    public GameObject memoryCanvas;
    public GameObject memories;
    public static GameObject memoriesS;

    public static bool isMenuClickable;

   
    public GameObject choiceButton;

    public GameObject trinkets;
    public static GameObject trinketsS;

    public GameObject clickBlocker;

    public List<GameObject> popups = new List<GameObject>();
    

    public AnimManager ac;

    public static MenuManager instance;

    void Awake()
    {
        isMenuClickable = true;
        memoriesS = this.memories;
        
        if(PlayerPrefs.GetInt("Choix affiché : ") == 1)
        {
            choiceButton.gameObject.SetActive(true);
        }
        trinketsS = this.trinkets;
       
        if (instance != null)
        {
            return;
        }
        instance = this;


    }

    void Start()
    {
        memoryCanvas.SetActive(false);
    }


    public void updateContent(GameObject content)
    {

        if (isMenuClickable)
        {

            if (currentContent == content && ac.isMenuOpen())
            {
                
                ac.closeMenu();
                clickBlocker.SetActive(false);
                closePopups();
            }
            else
            {
                if (currentContent != null)
                {
                    currentContent.SetActive(false);
                    closePopups();
                   
                }
                content.SetActive(true);
                currentContent = content;
                ac.openMenu();
            }
        }
       

    }

    public void closePopups()
    {
        foreach(GameObject g in popups)
        {
            g.SetActive(false);
        }
    }


    public static void addMemory(GameObject p)
    {
        Debug.Log(p.ToString());
        if (!memoriesS.activeSelf)
        {

            memoriesS.SetActive(true);

            Data.memoriesInstances.Add(Instantiate(p, memoriesS.gameObject.transform));
            
            memoriesS.SetActive(false);
        }
        else
        {
            Data.memoriesInstances.Add(Instantiate(p, memoriesS.gameObject.transform));
        }
        
    }

    public static void removeMemory(GameObject p)
    {
        Debug.Log(p.ToString());
        if (!memoriesS.activeSelf)
        {

            memoriesS.SetActive(true);
            Data.memoriesInstances.Remove(p);
            Destroy(p);
            memoriesS.SetActive(false);
        }
        else
        {
            Data.memoriesInstances.Remove(p);
            Destroy(p);
        }

    }

    public static void addTrinket(Trinket t)
    {

        Inventory.instance.Add(t);
    }
}
