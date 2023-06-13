using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VillagerScript : MonoBehaviour
{

    public bool isInRange;
    // Start is called before the first frame update
    [SerializeField] private float triggerRadius = 1.5f;
    [SerializeField] private KeyCode interactKey;

    private Image myImage;
    private Text npcText;
    private Text continueText;
    private Text nameText;

    private DialogueTrigger dialogueTrigger;

    private bool hasObtainedEntry = false;

    public void Start()
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
        npcText = myObjectText.GetComponent<Text>();
        continueText = objectContinueText.GetComponent<Text>();
        nameText = objectNameText.GetComponent<Text>();


    }

    // Update is called once per frame
    public void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {
            PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
            bool hasQuestItem = playerInventory.HasQuestItem();
            Debug.Log("Interacted with NPC...");
            //   GetComponent<Image>().gameObject.SetActive(true);

            myImage.enabled = true;
          //  npcText.text = "Hello there young man! I need to sauté some pork, but i'm out of garlic. Can you help me find some?";
            npcText.enabled = true;

            continueText.enabled = true;
            nameText.enabled = true;

            //FOR TESTING PURPOSES
            //hasQuestItem = true;

            if(!hasQuestItem)
            {
                Debug.Log("Quest Dialogue playing....");

                switch (SceneManager.GetActiveScene().name)
                {
                    case "AreaOne":
                        dialogueTrigger.TriggerDialogue("aswangQuest");
                        break;

                    case "AreaTwo":
                        dialogueTrigger.TriggerDialogue("diwataQuest");
                        break;
                    case "AreaThree":
                        dialogueTrigger.TriggerDialogue("bungisngisQuest");
                        break;

                    case "AreaFour":
                        dialogueTrigger.TriggerDialogue("pugotQuest");
                        break;

                    default:
                        break;


                }
            }
            else
            {
                Debug.Log("Information Dialogue playing....");

                switch (SceneManager.GetActiveScene().name)
                {
                    case "AreaOne":
                        dialogueTrigger.TriggerDialogue("aswangInfo");
                        break;

                    case "AreaTwo":
                        dialogueTrigger.TriggerDialogue("diwataInfo");
                        break;
                    case "AreaThree":
                        dialogueTrigger.TriggerDialogue("bungisngisInfo");
                        break;

                    case "AreaFour":
                        dialogueTrigger.TriggerDialogue("pugotInfo");
                        break;

                    default:
                        break;


                }

                if (!hasObtainedEntry)
                {
                    FindObjectOfType<AlmanacButtonManager>().almanac.GetComponent<AlmanacCanvas>().AddContentToAlmanac();
                    hasObtainedEntry = true;
                }
            }
            



        }
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
        npcText.enabled = false ;

        continueText.enabled = false;
        nameText.enabled = false;
    }
}