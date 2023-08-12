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
    private bool isCurrentlyPlaying = false;

    public void StartDialogue(DialogueSet dialogueSet)
    {
        if (isCurrentlyPlaying)
            return;

        npcDialogue.SetActive(true);
        nameText.text = dialogueSet.dialogue.name;
        isCurrentlyPlaying = true;
        currentSentenceQueue = new Queue<string>(dialogueSet.dialogue.sentences);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if(currentSentenceQueue.Count > 0)
        {
            string sentence = currentSentenceQueue.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
        else
        {
            EndDialogue();
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
        StopAllCoroutines();
        Debug.Log("End of conversation");
        npcDialogue.SetActive(false);
        isCurrentlyPlaying = false;
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
