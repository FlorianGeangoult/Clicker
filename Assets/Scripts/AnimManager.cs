using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimManager : MasterAnimManager
{
    public Animator MenuAnimator;
    public Animator TextBoxAnimator;
    public CanvasGroup UI;
    public Image ghostSprite;
    public Sprite normalSprite;

    public GameObject choice;

    public bool isReading;

    public CanvasGroup blackScreen;

    public GameObject ectoPopup;

    private Coroutine currentHurtAnim;

    private bool isClicking;

    public bool isHurt;
    


    public void interactMenu()
    {
        if (!MenuAnimator.GetBool("isOpen"))
        {
            openMenu();
        }

    }

    public bool isMenuOpen()
    {
        Debug.Log(MenuAnimator.GetBool("isOpen"));
        return MenuAnimator.GetBool("isOpen");
    }

    public void openMenu()
    {

        MenuAnimator.SetBool("isOpen", true);

    }

    public void closeMenu()
    {

        MenuAnimator.SetBool("isOpen", false);
        Debug.Log(MenuAnimator.GetBool("isOpen"));
    }


    public void openDialogueBox()
    {
        
        StartCoroutine(HideUI());
    }

    public void closeDialogueBox()
    {
        TextBoxAnimator.SetBool("isActive", false);
        StartCoroutine(ShowUI());
    }

    public void fadeToEnd()
    {
        TextBoxAnimator.SetBool("isActive", false);
        StartCoroutine(EndScreenFade());
    }

    public void fadeToScene()
    {
        TextBoxAnimator.SetBool("isActive", false);
        normalSprite = Data.currentGhost.idleSprite;
        this.ghostSprite.sprite = normalSprite;
        StartCoroutine(SceneFade());
    }

    public void activateChoice()
    {
        choice.SetActive(true);
    }
    public void closeChoice()
    {
        choice.SetActive(false);
        StartCoroutine(textPause());
    }

    IEnumerator textPause()
    {
        yield return new WaitForSeconds(0.5f);

        DialogueBox.instance.activateDialogue();
    }

    IEnumerator HideUI()
    {
        closeMenu();
        UI.interactable = false;
        for (float f = 0; f <= 1.5; f += Time.deltaTime)
        {
            UI.alpha = Mathf.Lerp(1f, 0f, f / 1.5f);
            yield return null;
        }
        UI.alpha = 0;
        
        UI.gameObject.SetActive(false);
        TextBoxAnimator.SetBool("isActive", true);
    }


    IEnumerator EndScreenFade()
    {
       
        yield return new WaitForSeconds(2f);

        blackScreen.gameObject.SetActive(true);

        for (float f = 0; f <= 1.5; f += Time.deltaTime)
        {
            blackScreen.alpha = Mathf.Lerp(0f, 1f, f / 1.5f);
            yield return null;
        }
        blackScreen.alpha = 1;

        if (Data.currentGhost.isHeaven)
        {
            FindObjectOfType<TransitionDialogueManager>().StartDialogue(Data.currentGhost.heavenEndingDialogue);
        }
        else
        {
            FindObjectOfType<TransitionDialogueManager>().StartDialogue(Data.currentGhost.hellEndingDialogue);
        }

    }

    IEnumerator SceneFade()
    {
       
        yield return new WaitForSeconds(2f);


        for (float f = 0; f <= 1.5; f += Time.deltaTime)
        {
            blackScreen.alpha = Mathf.Lerp(1f, 0f, f / 1.5f);
            yield return null;
        }
        blackScreen.alpha = 0;

        blackScreen.gameObject.SetActive(false);

        StartCoroutine(ShowUI());

    }


    IEnumerator ShowUI()
    {
       
        yield return new WaitForSeconds(1f);
        UI.gameObject.SetActive(true);
        UI.interactable = true;
      
        
        for (float f = 0; f <= 1.5; f += Time.deltaTime)
        {
            UI.alpha = Mathf.Lerp(0f, 1f, f / 1.5f);
            yield return null;
        }
        UI.alpha = 1;
        
    }

    public void ghostHurt()
    {
        Debug.Log(Input.mousePosition);
        FindObjectOfType<AudioManager>().Play("GhostSound");
        currentHurtAnim = StartCoroutine(ghostClickAnim(Data.currentGhost.hurtSprite)) ;
    }

    public void cancelGhostAnim()
    {
        if (currentHurtAnim != null) StopCoroutine(currentHurtAnim);
    }


    public void spawnPopup(GameObject popup, int amount)
    {
        StartCoroutine(destroyPopup(popup, amount));
    }

    IEnumerator destroyPopup(GameObject popup, int amount)
    {
        
        popup.GetComponentInChildren<Text>().text = "+ " + amount.ToString();
        for (float f = 0; f <= 0.4; f += Time.deltaTime)
        {
            popup.transform.position += new Vector3(0, 100 * Time.deltaTime, 0);
            yield return null;
        }
        
        Destroy(popup);
    }

    IEnumerator ghostClickAnim(Sprite hurt)
    {
        
        
        
        this.ghostSprite.sprite = hurt;
        yield return new WaitForSeconds(0.6f);
        
        this.ghostSprite.sprite = normalSprite;
        

    }




}
