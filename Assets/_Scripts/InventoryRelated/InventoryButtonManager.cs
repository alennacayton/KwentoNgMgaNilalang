using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonManager : MonoBehaviour
{

    public GameObject inventory;
    bool isOpen;
    bool isStartingCloseInventory = true;

    SoundEffects soundEffects;

    void Start()
    {
        soundEffects = FindObjectOfType<SoundEffects>();
        CloseInventory();
    }

    public void ButtonPressed()
    {
        if (!isOpen)
            OpenInventory();
        else
            CloseInventory();
    }

    void OpenInventory()
    {
        inventory.SetActive(true);
        isOpen = true;
        soundEffects.PlayInventoryClick(true);
    }

    void CloseInventory()
    {

        inventory.SetActive(false);
        isOpen = false;

        if (isStartingCloseInventory)
        {
            isStartingCloseInventory = false;
            return;
        }
        soundEffects.PlayInventoryClick(false);
    }


}
