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
        SetButtonEnabled();

        if (currentPageNumber > 0)
        {
            currentPageNumber--;
            SetPageContents();  
        }
    }

    public void TurnPageRight()
    {
        SetButtonEnabled();

        if (currentPageNumber < almanacContent.GetAlmanacLength() - 1)
        {
            currentPageNumber++;
            SetPageContents();
        }
    }

    void SetPageContents()
    {
        if (almanacContent.GetAlmanacLength() == 0)
        {
            creatureImage.sprite = null;
            SetTransparent(creatureImage, 0);

            creatureName.text = null;
            creatureDescription.text = null;
            return;
        }

        almanacEntry = almanacContent.GetPageContent(currentPageNumber);

        creatureImage.sprite = almanacEntry.creatureImage;
        SetTransparent(creatureImage, 1);

        creatureName.text = almanacEntry.creatureName;
        creatureDescription.text = almanacEntry.creatureDescription;
    }

    void SetButtonEnabled()
    {

        if(almanacContent.GetAlmanacLength() == 0)
        {
            leftButton.enabled = false;
            rightButton.enabled = false;

            SetTransparent(leftButton.image, 0);
            SetTransparent(rightButton.image, 0);

            return;
        }


        if(currentPageNumber == 0)
        { 
            leftButton.enabled = false;
            SetTransparent(leftButton.image, 0);
        }
        else
        {
            leftButton.enabled = true;
            SetTransparent(leftButton.image, 1);
        }

        if(currentPageNumber == almanacContent.GetAlmanacLength() - 1)
        {
            rightButton.enabled = false;
            SetTransparent(rightButton.image, 0);
        }
        else
        {
            rightButton.enabled = true;
            SetTransparent(rightButton.image, 1);
        }
    }

    public void AddContentToAlmanac()
    {
        almanacContent.AddEntry(newEntry);
        SetPageContents();
        SetButtonEnabled();
    }

    void SetTransparent(Image image, float transparency)
    {

        Color col = image.color;
        col.a = transparency;
        image.color = col;
    }
}
