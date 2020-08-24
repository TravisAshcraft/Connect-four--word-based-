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

    [SerializeField] GameObject[] squareSelector;

    //for generating random numbers
    int lastNumber;

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

    public void RollTheDice()
    {
        //this method is called on button press (when you click the dice)

        print("the number you rolled is " + GetRandomNumber(1, 6));
    }

    int GetRandomNumber(int min, int max)
    {
        int rand = UnityEngine.Random.Range(min, max);
        while (rand == lastNumber)
            rand = UnityEngine.Random.Range(min, max);
        lastNumber = rand;
        return rand;
    }
}
