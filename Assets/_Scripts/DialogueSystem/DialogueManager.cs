using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    public GameObject npcDialogue;
    public Text nameText;
    public Text dialogueText;
    public AudioSource typingAudioSource;
    public AudioClip typingSoundClip;

    private Queue<string> currentSentenceQueue;
    private bool isTextDisplaying;

    public void StartDialogue(DialogueSet dialogueSet)
    {
        npcDialogue.SetActive(true);
        nameText.text = dialogueSet.dialogue.name;

        currentSentenceQueue = new Queue<string>(dialogueSet.dialogue.sentences);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (currentSentenceQueue == null || currentSentenceQueue.Count == 0)
        {
            if (!isTextDisplaying) // Check if text is not currently being displayed
            {
                EndDialogue();
            }
            return;
        }

        if (isTextDisplaying)
        {
            return;
        }

        string sentence = currentSentenceQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        // Check if this is the last sentence
        if (currentSentenceQueue.Count == 0)
        {
            // Disable the "Continue" button or perform any other necessary actions
        }
    }


    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        isTextDisplaying = true;

        float delay = 0.03f;

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            PlayTypingSound();
            yield return new WaitForSeconds(delay);
        }

        isTextDisplaying = false;
    }

    void PlayTypingSound()
    {
        typingAudioSource.PlayOneShot(typingSoundClip);
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
        npcDialogue.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
