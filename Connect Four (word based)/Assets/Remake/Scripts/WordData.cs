using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WordData : MonoBehaviour
{
    string[] data = new string[36];
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void updateData(string[] str)
    {
        int counter = 0;
        foreach (string val in str)
        {
            data[counter] = val;
            counter++;


        }
    }

    public void printData()
    {
        foreach (string val in data)
        {
            Debug.Log(val);
        }
    }
}
