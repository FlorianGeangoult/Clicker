using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour   
{
    public static DialogueBox instance;
    public DialogueManager dm;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public void activateDialogue()
    {
        dm.isReading = true;
    }


}
