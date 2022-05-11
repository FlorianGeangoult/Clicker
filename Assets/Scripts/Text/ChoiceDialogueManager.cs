using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceDialogueManager : inGameDialogueManager
{


    


    public override void EndDialogue()
    {
        isReading = false;
        am.activateChoice();
        
      
    }
}
