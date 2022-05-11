using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryDialogueManager : inGameDialogueManager
{
    public override void EndDialogue()
    {
        isReading = false;
        am.closeDialogueBox();
     
    }
}
