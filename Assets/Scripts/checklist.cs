using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checklist : MonoBehaviour
{
    bool isinside = false;
    [SerializeField] TMP_Text infotext;
    [SerializeField] TimingManager tm;
    string onextra = "You have added extra items.";
    string oncorrect = "Well Done !!!.";
    string onwrong = "You have not added some items.";
    string onwrongextra = "You have added extra items and some items are missing.";
    string onbasketmissing = "Please place the basket near the door.";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("basket"))
        {
            print("isinside");
            isinside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("basket"))
        {
            print("notinside");
            isinside = false;
        }
    }


    public void check()
    {
        if (isinside)
        {
            //other.transform.position = transform.position;
            print("checking");

            tm.check();
            bool iswrong = false;
            bool isextra = false;
            foreach (KeyValuePair<int, int> kvp in taskgenerator.currentlist)
            {
                if (!taskgenerator.matchlist.ContainsKey(kvp.Key))
                {
                    isextra = true;
                    break;
                }

                if (taskgenerator.matchlist[kvp.Key] == kvp.Value)
                {
                    taskgenerator.texts[kvp.Key].GetComponent<TMP_Text>().color = Color.green;
                }
                else
                {
                    taskgenerator.texts[kvp.Key].GetComponent<TMP_Text>().color = Color.red;
                    iswrong = true;
                }
            }
            if (!iswrong && !isextra)
                infotext.text = oncorrect;
            else if (iswrong && !isextra)
                infotext.text = onwrong;
            else if (!iswrong && isextra)
                infotext.text = onextra;
            else
                infotext.text = onwrongextra;

        }
        else
            infotext.text = onbasketmissing;
    }
}
