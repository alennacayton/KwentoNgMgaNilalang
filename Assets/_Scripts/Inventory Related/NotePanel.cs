using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePanel : MonoBehaviour
{
    Image noteImage;
    Text noteText;
    Button noteButton;
    Image[] imagesInChildren;

    private void Awake()
    {
        noteImage = GetComponent<Image>();
        noteText = GetComponentInChildren<Text>();
        noteButton = GetComponentInChildren<Button>();
        imagesInChildren = GetComponentsInChildren<Image>();

        noteButton.onClick.AddListener(HideNote);
    }

    public void SetText(string message)
    {
        noteText.text = message;
    }

    public void ShowNote()
    {
        noteText.enabled = true;
        noteImage.enabled = true;
        noteButton.enabled = true;

        foreach(Image image in imagesInChildren)
        {
            image.enabled = true;
        }
    }

    public void HideNote()
    {
        noteText.enabled = false;
        noteImage.enabled = false;
        noteButton.enabled = false;

        foreach (Image image in imagesInChildren)
        {
            image.enabled = false;
        }
    }
}
