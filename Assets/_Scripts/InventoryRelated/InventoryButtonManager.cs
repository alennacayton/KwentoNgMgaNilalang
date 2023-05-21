using UnityEngine;
using UnityEngine.UI;

public class InventoryButtonManager : MonoBehaviour
{

    public GameObject inventory;
    bool isOpen = false;

    public void ButtonPressed()
    {
        isOpen = !isOpen;
        inventory.SetActive(isOpen);
    }


}
