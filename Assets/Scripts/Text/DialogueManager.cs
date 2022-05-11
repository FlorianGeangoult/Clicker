using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class DialogueManager : MonoBehaviour
{
    
    public Text dialogueText;

    public bool isReading;
  

    public DialogueTrigger dt;

    public MasterAnimManager textboxAnimator;

    public Queue<string> sentences;
    

    void Start()
    {
        sentences = new Queue<string>();
        
        textboxAnimator.showTextbox();
        dt.TriggerDialogue();
    }

    public virtual void StartDialogue(DialoguePortion dialoguePortion)
    {
        
        sentences.Clear();
        foreach (Dialogue dialogue in dialoguePortion.dialogues)
        {
            
                sentences.Enqueue(dialogue.sentence);
            
            
            
        }

        dialogueText.CrossFadeAlpha(0.0f, 0.0f, false);
        DisplayNextSentence();


    }

    void Update()
    {
        if (isReading)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                DisplayNextSentence();

            }
        }

    }

    public void DisplayNextSentence()
    {
        
        
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();



            Display(sentence);
        
        
    }

    public abstract void Display(string sentence);

    public abstract void EndDialogue();




}
