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

    public static Dictionary<int,TMP_Text> texts;
    void Start()
    {
        matchlist = new Dictionary<int,int>();
        currentlist = new Dictionary<int,int>();
        texts = new Dictionary<int, TMP_Text>();
    }

    public void newgame()
    {
        matchlist.Clear();
        currentlist.Clear();
        
        foreach(KeyValuePair<int, TMP_Text> kvp in texts)
        {
            Destroy(kvp.Value.gameObject);
        }
        
        texts.Clear();
        
        newlist(3);
        displaylist();
    }

    void newlist(int n,int maxcount =1)
    {
       
        int i = 0;
        int temp;
     
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
        TMP_Text text;
        foreach (KeyValuePair<int, int> kvp in matchlist)
        {
            temp = Instantiate(textprefab, textlayout.transform);
            text = temp.GetComponent<TMP_Text>();
            text.text = allitems[kvp.Key].name + "  " + kvp.Value.ToString();
            texts.Add(kvp.Key,text);
        }
    }
}
