using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmanacButtonManager : MonoBehaviour
{
    public GameObject almanac;
    bool isOpen;
    bool isStartingCloseAlmanac = true;

    SoundEffects soundEffects;

    void Start()
    {
        soundEffects = FindObjectOfType<SoundEffects>();
        CloseAlmanac();
    }

    public void ButtonPressed()
    {
        if (!isOpen)
            OpenAlmanac();
        else
            CloseAlmanac();
    }

    void OpenAlmanac()
    {
        almanac.SetActive(true);
        isOpen = true;
        soundEffects.PlayInventoryClick(true);
    }

    void CloseAlmanac()
    {
        almanac.SetActive(false);
        isOpen = false;

        if (isStartingCloseAlmanac)
        {
            isStartingCloseAlmanac = false;
            return;
        }

        soundEffects.PlayInventoryClick(false);
    }
}
