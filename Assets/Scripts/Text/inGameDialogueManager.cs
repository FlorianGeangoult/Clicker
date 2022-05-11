using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inGameDialogueManager : DialogueManager
{
    public Text nameText;

    public AnimManager am;

    public Queue<string> names;

    void Start()
    {
        names = new Queue<string>();
        sentences = new Queue<string>();
    }

    public override void Display(string sentence)
    {
        
        string name = names.Dequeue();
        dialogueText.text = sentence;
    }
    public override void StartDialogue(DialoguePortion dialoguePortion)
    {
        DialogueBox.instance.dm = (DialogueManager)this;
        am.openDialogueBox();
        sentences.Clear();
        foreach (Dialogue dialogue in dialoguePortion.dialogues)
        {

            sentences.Enqueue(dialogue.sentence);


            names.Enqueue(dialogue.name);

        }

        
        DisplayNextSentence();


    }




    public override void EndDialogue() { }
}
