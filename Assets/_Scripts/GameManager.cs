using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject note;

    private Text noteText;

    public void Awake()
    {
        noteText = GetComponentInChildren<Text>();
    }
    public void ShowNote(string text)
    {

    }
}
