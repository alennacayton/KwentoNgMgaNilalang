using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmanacButtonManager : MonoBehaviour
{
    public GameObject almanac;
    bool isOpen;

    void Start()
    {
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
    }

    void CloseAlmanac()
    {
        almanac.SetActive(false);
        isOpen = false;
    }
}
