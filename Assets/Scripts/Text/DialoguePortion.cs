using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue Portion")]
[System.Serializable]
public class DialoguePortion : ScriptableObject
{
    public Dialogue[] dialogues;
}
