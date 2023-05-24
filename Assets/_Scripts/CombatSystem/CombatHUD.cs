using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatHUD : MonoBehaviour
{

    public Text nameText;
    
    public void SetHUD(Unit unit)
    {
        nameText text = unit.unitName;
    }
}
