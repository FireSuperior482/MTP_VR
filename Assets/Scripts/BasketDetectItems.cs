using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketDetectItems : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        int id;
        try
        {
            id = other.GetComponent<itemid>().id;
        }
        catch
        {
            return;
        }

        print(id);

        if (taskgenerator.currentlist.ContainsKey(id))
        {
            taskgenerator.currentlist[id]++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        int id;

        try
        {
            id = other.GetComponent<itemid>().id;
        }
        catch
        {
            return;
        }

        print(id);

        if(taskgenerator.currentlist.ContainsKey(id))
        {
            taskgenerator.currentlist[id]--;
        }
    }

}
