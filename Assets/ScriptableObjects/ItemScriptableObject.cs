using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


[System.Serializable]
public struct Item
{
    public string name;
    public int id;
    public GameObject prefab;
}

[CreateAssetMenu]
public class Items : ScriptableObject
{
    public List<Item> items;
}
