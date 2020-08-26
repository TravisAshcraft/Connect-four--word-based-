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

    public enum GameMode
    {
        SINGLEPLAYER,
        MULTIPLAYER
    }
    public GameMode currentGameMode;

    public enum CurrentPlayerTurn
    {
        PLAYER_ONE,
        PLAYER_TWO,
        AI_TURN
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

    private void FixedUpdate()
    {
        switch (CurrentTurn)
        {
            case CurrentPlayerTurn.AI_TURN:

                AITURN();

                ChangeTurns();

                break;
        }
    }

    public void SetGameMode_Multiplayer()
    {
        currentGameMode = GameMode.MULTIPLAYER;
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
        switch (currentGameMode)
        {
            case GameMode.SINGLEPLAYER:
                switch (CurrentTurn)
                {
                    case CurrentPlayerTurn.PLAYER_ONE:
                        CurrentTurn = CurrentPlayerTurn.AI_TURN;
                        break;

                    case CurrentPlayerTurn.AI_TURN:
                        CurrentTurn = CurrentPlayerTurn.PLAYER_ONE;
                        break;
                }
                break;

            case GameMode.MULTIPLAYER:
                switch (CurrentTurn)
                {
                    case CurrentPlayerTurn.PLAYER_ONE:
                        CurrentTurn = CurrentPlayerTurn.PLAYER_TWO;
                        break;

                    case CurrentPlayerTurn.PLAYER_TWO:
                        CurrentTurn = CurrentPlayerTurn.PLAYER_ONE;
                        break;
                }
                break;
        }
    }

    public void AITURN()
    {
        int enemyRoll = GetRandomNumber(0, 36);

        if (enemyRoll == 0)
        {

        }
        else if (enemyRoll == 1)
        {

        }
        else if (enemyRoll == 2)
        {

        }
        else if (enemyRoll == 3)
        {

        }
        else if (enemyRoll == 4)
        {

        }
        else if (enemyRoll == 5)
        {

        }
        else if (enemyRoll == 6)
        {

        }
        else if (enemyRoll == 7)
        {

        }
        else if (enemyRoll == 8)
        {

        }
        else if (enemyRoll == 9)
        {

        }
        else if (enemyRoll == 10)
        {

        }
        else if (enemyRoll == 11)
        {

        }
        else if (enemyRoll == 12)
        {

        }
        else if (enemyRoll == 13)
        {

        }
        else if (enemyRoll == 14)
        {

        }
        else if (enemyRoll == 15)
        {

        }
        else if (enemyRoll == 16)
        {

        }
        else if (enemyRoll == 17)
        {

        }
        else if (enemyRoll == 18)
        {

        }
        else if (enemyRoll == 19)
        {

        }
        else if (enemyRoll == 20)
        {

        }
        else if (enemyRoll == 21)
        {

        }
        else if (enemyRoll == 22)
        {

        }
        else if (enemyRoll == 23)
        {

        }
        else if (enemyRoll == 24)
        {

        }
        else if (enemyRoll == 25)
        {

        }
        else if (enemyRoll == 26)
        {

        }
        else if (enemyRoll == 27)
        {

        }
        else if (enemyRoll == 28)
        {

        }
        else if (enemyRoll == 29)
        {

        }
        else if (enemyRoll == 30)
        {

        }
        else if (enemyRoll == 31)
        {

        }
        else if (enemyRoll == 32)
        {

        }
        else if (enemyRoll == 33)
        {

        }
        else if (enemyRoll == 34)
        {

        }
        else if (enemyRoll == 35)
        {

        }
        else if (enemyRoll == 36)
        {

        }

        Debug.Log(enemyRoll);
    }
}
