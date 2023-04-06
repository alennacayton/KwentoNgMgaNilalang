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

 
    public void Start()
    {
        isInRange = false;
        interactKey = KeyCode.E;
        GetComponent<CircleCollider2D>().radius = triggerRadius;



        // Get a reference to the GameObject
        GameObject myObject = GameObject.Find("NpcDialogue");
        GameObject myObjectText = GameObject.Find("NpcText");

        // Get a reference to the Image component on the GameObject
        myImage = myObject.GetComponent<Image>();
        npcText = myObjectText.GetComponent<Text>();

    }

    // Update is called once per frame
    public void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {
            Debug.Log("Hello There Young Man!!!");
            //   GetComponent<Image>().gameObject.SetActive(true);

            myImage.enabled = true;
            npcText.enabled = true;
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
    }
}