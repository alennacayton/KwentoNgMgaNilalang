using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VillagerScript : MonoBehaviour
{
    public bool isInRange;

    [SerializeField] private float triggerRadius = 1.5f;
    [SerializeField] private KeyCode interactKey;

    private Image myImage;
    private Text npcText;
    private Text continueText;
    private Text nameText;
    private DialogueTrigger dialogueTrigger;

    private bool hasObtainedEntry;

    private CircleCollider2D collider;

    private void Start()
    {
        isInRange = false;
        interactKey = KeyCode.E;
        collider = GetComponent<CircleCollider2D>();
        collider.radius = 0.69f;

        dialogueTrigger = GetComponent<DialogueTrigger>();

        // Get references to UI elements
        GameObject myObject = GameObject.Find("NpcDialogue");
        GameObject myObjectText = GameObject.Find("NpcText");
        GameObject objectContinueText = GameObject.Find("Continue");
        GameObject objectNameText = GameObject.Find("Name");

        myImage = myObject.GetComponent<Image>();
        npcText = myObjectText.GetComponent<Text>();
        continueText = objectContinueText.GetComponent<Text>();
        nameText = objectNameText.GetComponent<Text>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {
            PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
            bool hasQuestItem = playerInventory.HasQuestItem();
            Debug.Log("Interacted with NPC...");

            myImage.enabled = true;
            npcText.enabled = true;
            continueText.enabled = true;
            nameText.enabled = true;

            if (!hasQuestItem)
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

                    //FOR TESTING PURPOSES
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        myImage.enabled = false;
        npcText.enabled = false;
        continueText.enabled = false;
        nameText.enabled = false;
    }
}
