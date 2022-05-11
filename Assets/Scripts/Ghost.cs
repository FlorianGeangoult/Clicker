using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "NouveauFantôme", menuName = "Ghosts")]
public class Ghost : ScriptableObject
{
    public string ghostName;

    public bool isHeaven;

    public List<DialoguePortion> dialogues = new List<DialoguePortion>();
    public DialoguePortion choiceDialogue;
    public DialoguePortion heavenDialogue;
    public DialoguePortion heavenEndingDialogue;
    public DialoguePortion hellDialogue;
    public DialoguePortion hellEndingDialogue;

    public Sprite idleSprite;
    public Sprite hurtSprite;

    public GameObject[] upgrades;
}
