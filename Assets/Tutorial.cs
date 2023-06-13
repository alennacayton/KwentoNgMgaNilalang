using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Image myImage;
    [SerializeField]
    private Text npcText;
    [SerializeField]
    private Text continueText;
    [SerializeField]
    private Text nameText;
    [SerializeField]
    private DialogueTrigger dialogueTrigger;

    public void Start()
    {
      
        /*
        dialogueTrigger = GetComponent<DialogueTrigger>();


        // Get a reference to the GameObject
        GameObject myObject = GameObject.Find("NpcDialogue");
        GameObject myObjectText = GameObject.Find("NpcText");
        GameObject objectContinueText = GameObject.Find("Continue");
        GameObject objectNameText = GameObject.Find("Name");

        // Get a reference to the Image component on the GameObject
        myImage = myObject.GetComponent<Image>();
        npcText = myObjectText.GetComponent<Text>();
        continueText = objectContinueText.GetComponent<Text>();
        nameText = objectNameText.GetComponent<Text>();

        */
        myImage.enabled = true;
        //  npcText.text = "Hello there young man! I need to saut� some pork, but i'm out of garlic. Can you help me find some?";
        npcText.enabled = true;

        continueText.enabled = true;
        nameText.enabled = true;

        dialogueTrigger.TriggerDialogue("tutorial");


    }

    
}
