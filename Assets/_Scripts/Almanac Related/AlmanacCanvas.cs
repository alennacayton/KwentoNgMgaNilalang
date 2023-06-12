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
        currentPageNumber = 0;

        SetPageContents();
        SetButtonEnabled();
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
        if (almanacContent.GetAlmanacLength() == 0)
        {
            creatureImage.sprite = null;
            creatureName.text = null;
            creatureDescription.text = null;
            return;
        }

        almanacEntry = almanacContent.GetPageContent(currentPageNumber);

        creatureImage.sprite = almanacEntry.creatureImage;
        creatureName.text = almanacEntry.creatureName;
        creatureDescription.text = almanacEntry.creatureDescription;
    }

    void SetButtonEnabled()
    {
        Color col;

        if(almanacContent.GetAlmanacLength() == 0)
        {
            leftButton.enabled = false;
            rightButton.enabled = false;

            col = leftButton.image.color;
            col.a = 0;
            leftButton.image.color = col;

            col = rightButton.image.color;
            col.a = 0;
            rightButton.image.color = col;

            return;
        }


        if(currentPageNumber == 0)
        { 
            leftButton.enabled = false;

            col = leftButton.image.color;
            col.a = 0;
            leftButton.image.color = col;
        }
        else
        {
            leftButton.enabled = true;

            col = leftButton.image.color;
            col.a = 1;
            leftButton.image.color = col;
        }

        if(currentPageNumber == almanacContent.GetAlmanacLength() - 1)
        {
            rightButton.enabled = false;

            col = rightButton.image.color;
            col.a = 0;
            rightButton.image.color = col;
        }
        else
        {
            rightButton.enabled = true;

            col = rightButton.image.color;
            col.a = 1;
            rightButton.image.color = col;
        }
    }

    public void AddContentToAlmanac()
    {
        almanacContent.AddEntry(newEntry);
        SetPageContents();
        SetButtonEnabled();
    }

}
