using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Almanac Entry")]
public class AlmanacEntry : ScriptableObject
{
    public Sprite creatureImage;
    public string creatureName;

    [TextArea(20, 20)]
    public string creatureDescription;

    public bool isEncountered = false;
}
