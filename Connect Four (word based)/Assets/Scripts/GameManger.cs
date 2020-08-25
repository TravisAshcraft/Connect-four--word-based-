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

    public enum CurrentPlayerTurn
    {
        PLAYER_ONE,
        PLAYER_TWO
    }
    public CurrentPlayerTurn CurrentTurn;


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

    public void ChangeTurns()
    {
        switch (CurrentTurn)
        {
            case CurrentPlayerTurn.PLAYER_ONE:
                CurrentTurn = CurrentPlayerTurn.PLAYER_TWO;
                break;

            case CurrentPlayerTurn.PLAYER_TWO:
                CurrentTurn = CurrentPlayerTurn.PLAYER_ONE;
                break;
        }
    }
}
