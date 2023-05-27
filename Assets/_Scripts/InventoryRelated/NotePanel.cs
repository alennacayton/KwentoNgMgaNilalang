using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotePanel : MonoBehaviour
{
    Image noteImage;
    Text noteText;
    Button noteButton;
    
    private void Awake()
    {
        noteImage = GetComponent<Image>();
        noteText = GetComponentInChildren<Text>();
        noteButton = GetComponentInChildren<Button>();

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

        foreach(Image image in GetComponentsInChildren<Image>())
        {
            image.enabled = true;
        }
    }

    public void HideNote()
    {
        noteText.enabled = false;
        noteImage.enabled = false;
        noteButton.enabled = false;

        foreach (Image image in GetComponentsInChildren<Image>())
        {
            image.enabled = false;
        }
    }
}
