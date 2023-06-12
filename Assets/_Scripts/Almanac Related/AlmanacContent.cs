using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmanacContent : MonoBehaviour
{
    [SerializeField] private List<AlmanacEntry> almanacEntries = new List<AlmanacEntry>();
    [SerializeField] private int pageSoFar = 0;

    [SerializeField]

    private static AlmanacContent instance;

    void Awake()
    {

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);


    }

    public void AddEntry(AlmanacEntry almanacEntry)
    {
        almanacEntries.Add(almanacEntry);
    }

    public AlmanacEntry GetPageContent(int page)
    {
        return almanacEntries[page];
    }

    public int GetAlmanacLength()
    {
        return almanacEntries.Count;
    }
}
