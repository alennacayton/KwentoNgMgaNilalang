using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonManager : MonoBehaviour
{

    public GameObject inventory;
    bool isOpen;

    void Awake()
    {
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
    }

    void CloseInventory()
    {
        inventory.SetActive(false);
        isOpen = false;
    }


}
