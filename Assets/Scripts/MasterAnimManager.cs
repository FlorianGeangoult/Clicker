using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterAnimManager : MonoBehaviour
{
    public Animator textboxAnimator;

    public void showTextbox()
    {
        textboxAnimator.SetBool("isActive", true);
    }


    public void closeTextbox()
    {
        textboxAnimator.SetBool("isActive", false);
    }
}
