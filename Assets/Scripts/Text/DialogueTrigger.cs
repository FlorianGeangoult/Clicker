using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialoguePortion dialogue;

    public void TriggerDialogue()
    {
        
        FindObjectOfType<MemoryDialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerChoiceDialogue()
    {
        
        FindObjectOfType<ChoiceDialogueManager>().StartDialogue(Data.currentGhost.choiceDialogue);
    }

    public void TriggerHeavenEndDialogue()
    {
        Data.currentGhost.isHeaven = true;
        FindObjectOfType<EndDialogueManager>().StartDialogue(Data.currentGhost.heavenDialogue);
    }

    public void TriggerHellEndDialogue()
    {
        Data.currentGhost.isHeaven = false;
        FindObjectOfType<EndDialogueManager>().StartDialogue(Data.currentGhost.hellDialogue);
    }
}
