using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiwataScript : MonoBehaviour
{

    public bool isInRange;
    [SerializeField] private float triggerRadius = 1.5f;
    [SerializeField] private KeyCode interactKey;



    private Image myImage;
    private Text creatureText;
    private Text continueText;
    private Text nameText;


    private DialogueTrigger dialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isInRange = false;
        interactKey = KeyCode.E;
        GetComponent<CircleCollider2D>().radius = triggerRadius;
        dialogueTrigger = GetComponent<DialogueTrigger>();

        // Get a reference to the GameObject
        GameObject myObject = GameObject.Find("NpcDialogue");
        GameObject myObjectText = GameObject.Find("NpcText");
        GameObject objectContinueText = GameObject.Find("Continue");
        GameObject objectNameText = GameObject.Find("Name");

        // Get a reference to the Image component on the GameObject
        myImage = myObject.GetComponent<Image>();
        creatureText = myObjectText.GetComponent<Text>();
        continueText = objectContinueText.GetComponent<Text>();
        nameText = objectNameText.GetComponent<Text>();



    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {

            myImage.enabled = true;
            creatureText.enabled = true;
            continueText.enabled = true;
            nameText.enabled = true;

            dialogueTrigger.TriggerDialogue("diwataCombat");
            StartCoroutine(DelayedExecution());


        }
    }

    IEnumerator DelayedExecution()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(10f);

        // Code to execute after 5 seconds
        myImage.enabled = false;
        creatureText.enabled = false;
        continueText.enabled = false;
        nameText.enabled = false;

        SceneManager.LoadScene("DiwataQuiz");
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Item is In Range");
        isInRange = true;

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Item is Out of Range");
        isInRange = false;
        myImage.enabled = false;
        creatureText.enabled = false;
        continueText.enabled = false;
        nameText.enabled = false;
    }

}
