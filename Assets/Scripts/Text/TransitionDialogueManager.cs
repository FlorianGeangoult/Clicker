using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDialogueManager : inGameDialogueManager
{
    


    public override void EndDialogue()
    {
        isReading = false;
        Data.instance.nextGhost();
        am.fadeToScene();
        
        Debug.Log("mor");
    }

}
