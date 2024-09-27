using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public struct Item
{
    public string name;
    public int id;
    public GameObject prefab;
}

public class taskgenerator : MonoBehaviour
{
    public static Dictionary<int,int> matchlist, currentlist;
    [SerializeField] public List<Item> allitems;
    [SerializeField] GameObject textprefab;
    [SerializeField] GameObject textlayout;
    void Start()
    {
        matchlist = new Dictionary<int,int>();
        currentlist = new Dictionary<int,int>();

       
        newlist(2);
        displaylist();
        
    }

    void newlist(int n,int maxcount =1)
    {
       
        matchlist.Clear();
        int i = 0;
        int temp;
        print(allitems[0].name);

        while (i < n)
        {
            temp = Random.Range(0, allitems.Count);
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
            temp.GetComponent<TMP_Text>().text = allitems[kvp.Key].name + "  " + kvp.Value.ToString();
        }
    }
}
