using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonManager : MonoBehaviour
{

    public GameObject inventory;
    bool isOpen;

    void Awake()
    {
        isOpen = false;
        inventory.SetActive(isOpen);
    }

    public void ButtonPressed()
    {
        isOpen = !isOpen;
        inventory.SetActive(isOpen);
    }


}
