using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Almanac Entry")]
public class AlmanacEntry : ScriptableObject
{
    public Sprite creatureImage;
    public string creatureName;
    public List<string> creatureDescriptions = new List<string>();
    public bool isEncountered = false;
}
