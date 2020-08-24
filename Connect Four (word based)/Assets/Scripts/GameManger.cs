using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManger : MonoBehaviour
{
    [SerializeField] Text[] textFields;
    WordData data;
    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<WordData>();
        data.randomizeData();
        int counter = 0;
        foreach (Text tx in textFields)
        {
            tx.text = data.returnString(counter);
            counter++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
