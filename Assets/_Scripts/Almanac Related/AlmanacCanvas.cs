using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlmanacCanvas : MonoBehaviour
{
    [SerializeField] int currentPageNumber = 0;
    AlmanacContent almanacContent;
    AlmanacEntry almanacEntry;

    [SerializeField] AlmanacEntry newEntry;

    [SerializeField] Button leftButton, rightButton;
    [SerializeField] Image creatureImage;
    [SerializeField] TextMeshProUGUI creatureName;
    [SerializeField] TextMeshProUGUI creatureDescription;

    private void Awake()
    {
        almanacContent = FindObjectOfType<AlmanacContent>();
        almanacContent.AddEntry(newEntry);
    }

    private void Start()
    {
        currentPageNumber = 0;
        SetPageContents();
    }

    public void TurnPageLeft()
    {
        if(currentPageNumber > 0)
        {
            currentPageNumber--;
            SetPageContents();  
        }

        SetButtonEnabled();
    }

    public void TurnPageRight()
    {
        if (currentPageNumber < almanacContent.GetAlmanacLength() - 1)
        {
            currentPageNumber++;
            SetPageContents();
        }

        SetButtonEnabled();
    }

    void SetPageContents()
    {

        almanacEntry = almanacContent.GetPageContent(currentPageNumber);


        creatureImage.sprite = almanacEntry.creatureImage;
        creatureName.text = almanacEntry.creatureName;

        foreach (string description in almanacEntry.creatureDescriptions)
        {
            creatureDescription.text += "- " + description + "\n";
        }
    }

    void SetButtonEnabled()
    {
        if(currentPageNumber == 0)
        {
            leftButton.enabled = false;
        }
        else
        {
            leftButton.enabled = true;
        }


        if(currentPageNumber == almanacContent.GetAlmanacLength() - 1)
        {
            rightButton.enabled = false;
        }
        else
        {
            rightButton.enabled = true;
        }
    }


}