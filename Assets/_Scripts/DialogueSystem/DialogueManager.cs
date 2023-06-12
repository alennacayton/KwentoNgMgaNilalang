using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> currentSentenceQueue;

    public void StartDialogue(DialogueSet dialogueSet)
    {
        nameText.text = dialogueSet.dialogue.name;

        currentSentenceQueue = new Queue<string>(dialogueSet.dialogue.sentences);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (currentSentenceQueue == null || currentSentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = currentSentenceQueue.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
