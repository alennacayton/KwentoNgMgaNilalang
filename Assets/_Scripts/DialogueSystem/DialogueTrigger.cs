using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueSet[] dialogueSets;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    public void TriggerDialogue(string condition)
    {
        foreach (DialogueSet dialogueSet in dialogueSets)
        {
            if (dialogueSet.condition == condition)
            {
                dialogueManager.StartDialogue(dialogueSet);
                return;
            }
        }

        Debug.LogWarning("No dialogue set found for condition: " + condition);
    }
}

[System.Serializable]
public class DialogueSet
{
    public Dialogue dialogue;
    public string condition;
}
