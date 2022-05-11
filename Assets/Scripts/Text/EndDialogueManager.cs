using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogueManager : inGameDialogueManager
{
    public override void StartDialogue(DialoguePortion dialoguePortion)
    {
        DialogueBox.instance.dm = this;
        am.closeChoice();
        //am.openDialogueBox();
        sentences.Clear();
        foreach (Dialogue dialogue in dialoguePortion.dialogues)
        {

            sentences.Enqueue(dialogue.sentence);


            names.Enqueue(dialogue.name);

        }
       

        DisplayNextSentence();


    }




    public override void EndDialogue()
    {
        isReading = false;
        am.fadeToEnd();
        Debug.Log("mor");
    }
}
