using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class GameManger : MonoBehaviour
{
    [SerializeField] Text[] textFields;
    WordData data;

    [SerializeField] GameObject[] squareHiders;

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

    //AI Variables
    public bool[] alreadySelected;
    public int enemyRoll;
    public Color aiSelect_Color;

    // Start is called before the first frame update
    void Start()
    {
        //data = FindObjectOfType<WordData>();
        //data.randomizeData();
        //int counter = 0;
        //foreach (Text tx in textFields)
        //{
        //    tx.text = data.returnString(counter);
        //    counter++;
        //}

        SettingGameStart();
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

    public void RollTheDice_One()
    {
        //rolls the first dice
        int diceRollOne = GetRandomNumber(1, 7);

        print("the first dice rolled " + diceRollOne);

        if(diceRollOne == 1)
        {
            squareHiders[0].SetActive(false);
        }
        else if (diceRollOne == 2)
        {
            squareHiders[6].SetActive(false);
        }
        else if (diceRollOne == 3)
        {
            squareHiders[12].SetActive(false);
        }
        else if (diceRollOne == 4)
        {
            squareHiders[18].SetActive(false);
        }
        else if (diceRollOne == 5)
        {
            squareHiders[24].SetActive(false);
        }
        else if(diceRollOne == 6)
        {
            squareHiders[30].SetActive(false);
        }
        else
        {
            Debug.Log("Error rolling dice one.");
        }
    }

    public void RollTheDice_Two()
    {
        //rolls the second dice
        int diceRollTwo = GetRandomNumber(1, 7);

        print("the second dice rolled " + diceRollTwo);

        if (diceRollTwo == 1)
        {
            squareHiders[1].SetActive(false);
        }
        else if (diceRollTwo == 2)
        {
            squareHiders[7].SetActive(false);
        }
        else if (diceRollTwo == 3)
        {
            squareHiders[13].SetActive(false);
        }
        else if (diceRollTwo == 4)
        {
            squareHiders[19].SetActive(false);
        }
        else if (diceRollTwo == 5)
        {
            squareHiders[25].SetActive(false);
        }
        else if (diceRollTwo == 6)
        {
            squareHiders[31].SetActive(false);
        }
        else
        {
            Debug.Log("Error rolling dice two.");
        }
    }

    public void RollTheDice_Three()
    {
        //rolls the third dice
        int diceRollThree = GetRandomNumber(1, 7);

        print("the third dice rolled " + diceRollThree);

        if (diceRollThree == 1)
        {
            squareHiders[2].SetActive(false);
        }
        else if (diceRollThree == 2)
        {
            squareHiders[8].SetActive(false);
        }
        else if (diceRollThree == 3)
        {
            squareHiders[14].SetActive(false);
        }
        else if (diceRollThree == 4)
        {
            squareHiders[20].SetActive(false);
        }
        else if (diceRollThree == 5)
        {
            squareHiders[26].SetActive(false);
        }
        else if (diceRollThree == 6)
        {
            squareHiders[32].SetActive(false);
        }
        else
        {
            Debug.Log("Error rolling dice three.");
        }
    }

    public void RollTheDice_Four()
    {
        //rolls the fourth dice
        int diceRollFour = GetRandomNumber(1, 7);

        print("the fourth dice rolled " + diceRollFour);

        if (diceRollFour == 1)
        {
            squareHiders[3].SetActive(false);
        }
        else if (diceRollFour == 2)
        {
            squareHiders[9].SetActive(false);
        }
        else if (diceRollFour == 3)
        {
            squareHiders[15].SetActive(false);
        }
        else if (diceRollFour == 4)
        {
            squareHiders[21].SetActive(false);
        }
        else if (diceRollFour == 5)
        {
            squareHiders[27].SetActive(false);
        }
        else if (diceRollFour == 6)
        {
            squareHiders[33].SetActive(false);
        }
        else
        {
            Debug.Log("Error rolling dice four.");
        }
    }

    public void RollTheDice_Five()
    {
        //rolls the fifth dice
        int diceRollFive = GetRandomNumber(1, 7);

        print("the fifth dice rolled " + diceRollFive);

        if (diceRollFive == 1)
        {
            squareHiders[4].SetActive(false);
        }
        else if (diceRollFive == 2)
        {
            squareHiders[10].SetActive(false);
        }
        else if (diceRollFive == 3)
        {
            squareHiders[16].SetActive(false);
        }
        else if (diceRollFive == 4)
        {
            squareHiders[22].SetActive(false);
        }
        else if (diceRollFive == 5)
        {
            squareHiders[28].SetActive(false);
        }
        else if (diceRollFive == 6)
        {
            squareHiders[34].SetActive(false);
        }
        else
        {
            Debug.Log("Error rolling dice five.");
        }
    }

    public void RollTheDice_Six()
    {
        //rolls the sixth dice
        int diceRollSix = GetRandomNumber(1, 7);

        print("the sixth dice rolled " + diceRollSix);

        if (diceRollSix == 1)
        {
            squareHiders[5].SetActive(false);
        }
        else if (diceRollSix == 2)
        {
            squareHiders[11].SetActive(false);
        }
        else if (diceRollSix == 3)
        {
            squareHiders[17].SetActive(false);
        }
        else if (diceRollSix == 4)
        {
            squareHiders[23].SetActive(false);
        }
        else if (diceRollSix == 5)
        {
            squareHiders[29].SetActive(false);
        }
        else if (diceRollSix == 6)
        {
            squareHiders[35].SetActive(false);
        }
        else
        {
            Debug.Log("Error rolling dice six.");
        }
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

    void SettingGameStart()
    {
        alreadySelected [0] = false;
        alreadySelected [1] = false;
        alreadySelected [2] = false;
        alreadySelected [3] = false;
        alreadySelected [4] = false;
        alreadySelected [5] = false;
        alreadySelected [6] = false;
        alreadySelected [7] = false;
        alreadySelected [8] = false;
        alreadySelected [9] = false;
        alreadySelected [10] = false;
        alreadySelected [11] = false;
        alreadySelected [12] = false;
        alreadySelected [13] = false;
        alreadySelected [14] = false;
        alreadySelected [15] = false;
        alreadySelected [16] = false;
        alreadySelected [17] = false;
        alreadySelected [18] = false;
        alreadySelected [19] = false;
        alreadySelected [20] = false;
        alreadySelected [21] = false;
        alreadySelected [22] = false;
        alreadySelected [23] = false;
        alreadySelected [24] = false;
        alreadySelected [25] = false;
        alreadySelected [26] = false;
        alreadySelected [27] = false;
        alreadySelected [28] = false;
        alreadySelected [29] = false;
        alreadySelected [30] = false;
        alreadySelected [31] = false;
        alreadySelected [32] = false;
        alreadySelected [33] = false;
        alreadySelected [34] = false;
        alreadySelected [35] = false;

        Debug.Log("AI initialized");
    }

    public void AITURN()
    {
        enemyRoll = GetRandomNumber(0, 35);

        if (enemyRoll == 0 && alreadySelected[0] == false)
        {
            alreadySelected[0] = true;

            squareSelector[0].SetActive(true);

            squareSelector[0].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[0].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 1 && alreadySelected[1] == false)
        {
            alreadySelected[1] = true;

            squareSelector[1].SetActive(true);

            squareSelector[1].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[1].GetComponent<Image>().color = aiSelect_Color;

        }
        else if (enemyRoll == 2 && alreadySelected[2] == false)
        {
            alreadySelected[2] = true;

            squareSelector[2].SetActive(true);

            squareSelector[2].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[2].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 3 && alreadySelected[3] == false)
        {
            alreadySelected[3] = true;

            squareSelector[3].SetActive(true);

            squareSelector[3].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[3].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 4 && alreadySelected[4] == false)
        {
            alreadySelected[4] = true;

            squareSelector[4].SetActive(true);

            squareSelector[4].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[4].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 5 && alreadySelected[5] == false)
        {
            alreadySelected[5] = true;

            squareSelector[5].SetActive(true);

            squareSelector[5].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[5].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 6 && alreadySelected[6] == false)
        {
            alreadySelected[6] = true;

            squareSelector[6].SetActive(true);

            squareSelector[6].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[6].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 7 && alreadySelected[7] == false)
        {
            alreadySelected[7] = true;

            squareSelector[7].SetActive(true);

            squareSelector[7].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[7].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 8 && alreadySelected[8] == false)
        {
            alreadySelected[8] = true;

            squareSelector[8].SetActive(true);

            squareSelector[8].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[8].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 9 && alreadySelected[9] == false)
        {
            alreadySelected[9] = true;

            squareSelector[9].SetActive(true);

            squareSelector[9].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[9].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 10 && alreadySelected[10] == false)
        {
            alreadySelected[10] = true;

            squareSelector[10].SetActive(true);

            squareSelector[10].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[10].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 11 && alreadySelected[11] == false)
        {
            alreadySelected[11] = true;

            squareSelector[11].SetActive(true);

            squareSelector[11].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[11].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 12 && alreadySelected[12] == false)
        {
            alreadySelected[12] = true;

            squareSelector[12].SetActive(true);

            squareSelector[12].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[12].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 13 && alreadySelected[13] == false)
        {
            alreadySelected[13] = true;

            squareSelector[13].SetActive(true);

            squareSelector[13].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[13].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 14 && alreadySelected[14] == false)
        {
            alreadySelected[14] = true;

            squareSelector[14].SetActive(true);

            squareSelector[14].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[14].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 15 && !alreadySelected[15])
        {
            alreadySelected[15] = true;

            squareSelector[15].SetActive(true);

            squareSelector[15].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[15].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 16 && !alreadySelected[16])
        {
            alreadySelected[16] = true;

            squareSelector[16].SetActive(true);

            squareSelector[16].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[16].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 17 && !alreadySelected[17])
        {
            alreadySelected[17] = true;

            squareSelector[17].SetActive(true);

            squareSelector[17].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[17].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 18 && !alreadySelected[18])
        {
            alreadySelected[18] = true;

            squareSelector[18].SetActive(true);

            squareSelector[18].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[18].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 19 && !alreadySelected[19])
        {
            alreadySelected[19] = true;

            squareSelector[19].SetActive(true);

            squareSelector[19].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[19].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 20 && !alreadySelected[20])
        {
            alreadySelected[20] = true;

            squareSelector[20].SetActive(true);

            squareSelector[20].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[20].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 21 && !alreadySelected[21])
        {
            alreadySelected[21] = true;

            squareSelector[21].SetActive(true);

            squareSelector[21].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[21].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 22 && !alreadySelected[22])
        {
            alreadySelected[22] = true;

            squareSelector[22].SetActive(true);

            squareSelector[22].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[22].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 23 && !alreadySelected[23])
        {
            alreadySelected[23] = true;

            squareSelector[23].SetActive(true);

            squareSelector[23].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[23].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 24 && !alreadySelected[24])
        {
            alreadySelected[24] = true;

            squareSelector[24].SetActive(true);

            squareSelector[24].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[24].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 25 && !alreadySelected[25])
        {
            alreadySelected[25] = true;

            squareSelector[25].SetActive(true);

            squareSelector[25].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[25].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 26 && !alreadySelected[26])
        {
            alreadySelected[26] = true;

            squareSelector[26].SetActive(true);

            squareSelector[26].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[26].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 27 && !alreadySelected[27])
        {
            alreadySelected[27] = true;

            squareSelector[27].SetActive(true);

            squareSelector[27].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[27].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 28 && !alreadySelected[28])
        {
            alreadySelected[28] = true;

            squareSelector[28].SetActive(true);

            squareSelector[28].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[28].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 29 && !alreadySelected[29])
        {
            alreadySelected[29] = true;

            squareSelector[29].SetActive(true);

            squareSelector[29].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[29].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 30 && !alreadySelected[30])
        {
            alreadySelected[30] = true;

            squareSelector[30].SetActive(true);

            squareSelector[30].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[30].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 31 && !alreadySelected[31])
        {
            alreadySelected[31] = true;

            squareSelector[31].SetActive(true);

            squareSelector[31].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[31].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 32 && !alreadySelected[32])
        {
            alreadySelected[32] = true;

            squareSelector[32].SetActive(true);

            squareSelector[32].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[32].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 33 && !alreadySelected[33])
        {
            alreadySelected[33] = true;

            squareSelector[33].SetActive(true);

            squareSelector[33].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[33].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 34 && !alreadySelected[34])
        {
            alreadySelected[34] = true;

            squareSelector[34].SetActive(true);

            squareSelector[34].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[34].GetComponent<Image>().color = aiSelect_Color;
        }
        else if (enemyRoll == 35 && !alreadySelected[35])
        {
            alreadySelected[35] = true;

            squareSelector[35].SetActive(true);

            squareSelector[35].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;

            squareSelector[35].GetComponent<Image>().color = aiSelect_Color;
        }

        else
        {
            Debug.Log("Error, AI can't choose this spot. AI will try again.");
            AITURN();
        }

        Debug.Log(enemyRoll);
    }

    public void RemoveButtonA1()
    {
        alreadySelected[0] = true;
    }

    public void RemoveButtonA2()
    {
        alreadySelected[1] = true;
    }

    public void RemoveButtonA3()
    {
        alreadySelected[2] = true;
    }

    public void RemoveButtonA4()
    {
        alreadySelected[3] = true;
    }

    public void RemoveButtonA5()
    {
        alreadySelected[4] = true;
    }

    public void RemoveButtonA6()
    {
        alreadySelected[5] = true;
    }

    public void RemoveButtonB1()
    {
        alreadySelected[6] = true;
    }

    public void RemoveButtonB2()
    {
        alreadySelected[7] = true;
    }

    public void RemoveButtonB3()
    {
        alreadySelected[8] = true;
    }

    public void RemoveButtonB4()
    {
        alreadySelected[9] = true;
    }

    public void RemoveButtonB5()
    {
        alreadySelected[10] = true;
    }

    public void RemoveButtonB6()
    {
        alreadySelected[11] = true;
    }

    public void RemoveButtonC1()
    {
        alreadySelected[12] = true;
    }

    public void RemoveButtonC2()
    {
        alreadySelected[13] = true;
    }

    public void RemoveButtonC3()
    {
        alreadySelected[14] = true;
    }

    public void RemoveButtonC4()
    {
        alreadySelected[15] = true;
    }

    public void RemoveButtonC5()
    {
        alreadySelected[16] = true;
    }

    public void RemoveButtonC6()
    {
        alreadySelected[17] = true;
    }

    public void RemoveButtonD1()
    {
        alreadySelected[18] = true;
    }

    public void RemoveButtonD2()
    {
        alreadySelected[19] = true;
    }

    public void RemoveButtonD3()
    {
        alreadySelected[20] = true;
    }

    public void RemoveButtonD4()
    {
        alreadySelected[21] = true;
    }

    public void RemoveButtonD5()
    {
        alreadySelected[22] = true;
    }

    public void RemoveButtonD6()
    {
        alreadySelected[23] = true;
    }

    public void RemoveButtonE1()
    {
        alreadySelected[24] = true;
    }

    public void RemoveButtonE2()
    {
        alreadySelected[25] = true;
    }

    public void RemoveButtonE3()
    {
        alreadySelected[26] = true;
    }

    public void RemoveButtonE4()
    {
        alreadySelected[27] = true;
    }

    public void RemoveButtonE5()
    {
        alreadySelected[28] = true;
    }

    public void RemoveButtonE6()
    {
        alreadySelected[29] = true;
    }

    public void RemoveButtonF1()
    {
        alreadySelected[30] = true;
    }

    public void RemoveButtonF2()
    {
        alreadySelected[31] = true;
    }

    public void RemoveButtonF3()
    {
        alreadySelected[32] = true;
    }

    public void RemoveButtonF4()
    {
        alreadySelected[33] = true;
    }

    public void RemoveButtonF5()
    {
        alreadySelected[34] = true;
    }

    public void RemoveButtonF6()
    {
        alreadySelected[35] = true;
    }
}
