using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteText : MonoBehaviour
{
    Text noteText; 
    private void Awake()
    {
        noteText = GetComponent<Text>();
    }

    public void SetText(string message)
    {
        noteText.text = message;
    }
}
