using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatHUD : MonoBehaviour
{

    public Text nameText;
    [SerializeField]
    private Sprite[] livesSprites;
    [SerializeField]
    private Image livesImage;
    
    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;

    }

    // lives counter for player
    public void updateLives(int currLives)
    {
        livesImage.sprite = livesSprites[currLives];
    }
}
