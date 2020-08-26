using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordData : MonoBehaviour
{
    List<string> data= new List<string>();
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void updateData(List<string> str)
    {
        foreach (string val in str)
        {
            data.Add(val);
        }
    }

    public string returnString(int i)
    {
        string val = data[i];
        return val;
    }

    public void printData()
    {
        foreach (string val in data)
        {
            Debug.Log(val);
        }
    }

    public void randomizeData()
    {
        for (int i = 0; i < data.Count; i++)
        {
            string temp = data[i];
            int randomIndex = Random.Range(i, data.Count);
            data[i] = data[randomIndex];
            data[randomIndex] = temp;
        }
    }
}
