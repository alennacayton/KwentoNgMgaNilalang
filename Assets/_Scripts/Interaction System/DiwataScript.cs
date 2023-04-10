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
    private Text aswangText;

    // Start is called before the first frame update
    void Start()
    {
        isInRange = false;
        interactKey = KeyCode.E;
        GetComponent<CircleCollider2D>().radius = triggerRadius;

        // Get a reference to the GameObject
        GameObject myObject = GameObject.Find("NpcDialogue");
        GameObject myObjectText = GameObject.Find("NpcText");

        // Get a reference to the Image component on the GameObject
        myImage = myObject.GetComponent<Image>();
        aswangText = myObjectText.GetComponent<Text>();




    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(interactKey))
        {


            myImage.enabled = true;
            aswangText.text = "Kumusta?";
            aswangText.enabled = true;


            StartCoroutine(DelayedExecution());


        }
    }

    IEnumerator DelayedExecution()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(2f);

        // Code to execute after 5 seconds
        myImage.enabled = false;
        aswangText.enabled = false;

        SceneManager.LoadScene("DiwataCombat");
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
    }

}
