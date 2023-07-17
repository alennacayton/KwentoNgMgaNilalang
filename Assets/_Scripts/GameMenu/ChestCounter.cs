using UnityEngine;
using UnityEngine.UI;

public class ChestCounter : MonoBehaviour
{ private int chestsObtained;
    [SerializeField]
    private Text textComponent;

    private void Start()
    {
        
        textComponent = GetComponent<Text>();
     
    }

   

    private void Update()
    {

        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        int numNotes = playerInventory.GetNoteItemCount();

        textComponent.text = numNotes + "/" + 3;

    }


}
