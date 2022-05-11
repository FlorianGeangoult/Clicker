using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroDialogueManager : DialogueManager
{
    private int sentencesNumber;
    public Sprite[] fonds;
    public Sprite currentSprite;

    public Image fond;

    

    public override void Display(string sentence)
    {
        StartCoroutine(showSentence(sentence));
    }

    IEnumerator showSentence(string sentence)
    {
        sentencesNumber += 1;
        switch(sentencesNumber)
        {
            case 1:
                currentSprite = fonds[0];
                fond.sprite = currentSprite;
                fond.CrossFadeAlpha(0.0f, 0.0f, false);

                break;
            case 2:
                
                fond.CrossFadeAlpha(0.0f, 0.5f, false);


                break;
            case 3:
               
                fond.CrossFadeAlpha(0.0f, 0.5f, false);


                break;

            case 5:
               
                fond.CrossFadeAlpha(0.0f, 0.5f, false);


                break;
            case 7:
               
                fond.CrossFadeAlpha(0.0f, 0.5f, false);


                break;
            case 8:
                
                fond.CrossFadeAlpha(0.0f, 0.5f, false);


                break;

        }
        dialogueText.CrossFadeAlpha(0.0f, 0.5f, false);
        yield return new WaitForSeconds(0.5f);
        switch (sentencesNumber)
        {
            case 1:
                currentSprite = fonds[0];
                fond.sprite = currentSprite;
               

                break;
            case 2:
                currentSprite = fonds[1];
                fond.sprite = currentSprite;
                


                break;
            case 3:
                currentSprite = fonds[2];
                fond.sprite = currentSprite;
                


                break;

            case 5:
                currentSprite = fonds[3];
                fond.sprite = currentSprite;
                


                break;
            case 7:
                currentSprite = fonds[4];
                fond.sprite = currentSprite;
                


                break;
            case 8:
                currentSprite = fonds[0];
                fond.sprite = currentSprite;
                


                break;

        }
        dialogueText.text = sentence;
        dialogueText.CrossFadeAlpha(1.0f, 0.5f, false);
        fond.CrossFadeAlpha(1.0f, 0.5f, false);

    }


    public override void EndDialogue()
    {
        textboxAnimator.closeTextbox();
        
            StartCoroutine(ChargeScene(SceneManager.GetActiveScene().buildIndex + 1));

        
    }

    public override void StartDialogue(DialoguePortion dialoguePortion)
    {

        sentences.Clear();
        foreach (Dialogue dialogue in dialoguePortion.dialogues)
        {

            sentences.Enqueue(dialogue.sentence);



        }

        dialogueText.CrossFadeAlpha(0.0f, 0.0f, false);
        DisplayNextSentence();
    }



    IEnumerator ChargeScene(int sceneIndex)
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);

    }
}
