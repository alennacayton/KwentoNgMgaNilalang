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
            EndDialogue();
            return;
        }

        string sentence = currentSentenceQueue.Dequeue();
        // dialogueText.text = sentence;'
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    
    /*
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        
        foreach (char letter in sentence.ToCharArray())
        {
            //PlayTypingSound();
            yield return new WaitForSeconds(0.02f);
            dialogueText.text += letter;
            yield return null;
        }
    }
    
*/
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        // Calculate the delay for each character based on the length of the audio clip
     //   float delay = typingSoundClip.length / sentence.Length;

        float delay = 0.03f; // Increase this value for a slower typing speed


        foreach (char letter in sentence.ToCharArray())
        {
           
            dialogueText.text += letter;
            PlayTypingSound();
            yield return new WaitForSeconds(delay);
        }
    }
    

    void PlayTypingSound()
    {
        typingAudioSource.PlayOneShot(typingSoundClip);
    }

    
    void EndDialogue()
    {
        Debug.Log("End of conversation");
        npcDialogue.SetActive(false);

        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
