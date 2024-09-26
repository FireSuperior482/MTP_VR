using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class taskgenerator : MonoBehaviour
{
    public static Dictionary<int,int> matchlist, currentlist;
    [SerializeField] Items allitems;
    [SerializeField] GameObject textprefab;
    [SerializeField] GameObject textlayout;

    void Start()
    {
        matchlist = new Dictionary<int,int>();
        currentlist = new Dictionary<int,int>();
        newlist(5);
        displaylist();
    }

    void newlist(int n,int maxcount =1)
    {
        matchlist.Clear();
        int i = 0;
        int temp;
        while (i < n)
        {
            temp = Random.Range(0, allitems.items.Count);
            if (!matchlist.ContainsKey(temp))
            {
                matchlist.Add(temp, 1);
                currentlist.Add(temp, 0);
                i++;
            }
        }

    }

    void displaylist()
    {
        GameObject temp;
        foreach (KeyValuePair<int, int> kvp in matchlist)
        {
            temp = Instantiate(textprefab, textlayout.transform);
            temp.GetComponent<TMP_Text>().text = allitems.items[kvp.Key].name + "  " + kvp.Value.ToString();
        }
    }
}
