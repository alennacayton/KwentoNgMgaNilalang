using UnityEngine;

[CreateAssetMenu(fileName = "New Note", menuName = "Custom/Note")]
public class Note : ScriptableObject
{
    public string title;
    public string message;
    public int tag;

    public void ResetTags()
    {
        tag = 0;
    }
}
