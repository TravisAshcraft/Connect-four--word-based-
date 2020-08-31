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
    [SerializeField] List<string> textFields = new List<string>();
    //WordData data;

    [SerializeField] Text[] theWords;

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
    bool aiTurnSuccess = false;
    public bool[] alreadySelected;
    public int enemyRoll;
    public Color aiSelect_Color;

    public bool columnOne_Active = false;
    public bool columnTwo_Active = false;
    public bool columnThree_Active = false;
    public bool columnFour_Active = false;
    public bool columnFive_Active = false;
    public bool columnSix_Active = false;

    public enum ActiveColumns
    {
        ONEACTIVE,
        TWOACTIVE,
        THREEACTIVE,
        FOURACTIVE,
        FIVEACTIVE,
        ALLACTIVE
    }
    public ActiveColumns Num_ColumnsActive;

    int numOfColumnsActive = 0;

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

        //populate the text fields with the words we input
        Invoke("PopulateTextFields", 0.2f);
    }

    private void FixedUpdate()
    {
        switch (CurrentTurn)
        {
            case CurrentPlayerTurn.AI_TURN:

                AITURN();

                if (aiTurnSuccess)
                {
                    ChangeTurns();
                    aiTurnSuccess = false;
                }
                break;
        }
    }

    public void SetGameMode_Multiplayer()
    {
        currentGameMode = GameMode.MULTIPLAYER;
    }

    public void PopulateTextFields()
    {
        textFields = GameObject.Find("WordPool").GetComponent<WordPool>().inputWords;

        int numberOfWordsUsed = GameObject.Find("WordPool").GetComponent<WordPool>().inputWords.Count;

        for(int i = 0; i < theWords.Length; i++)
        {
            theWords[i].text = textFields[GetRandomNumber(0, numberOfWordsUsed)].ToString();
        }


        //below is a horrible sloppy way of populating, but it does what the for loop above does

        //theWords[0].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[1].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[2].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[3].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[4].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[5].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[6].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[7].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[8].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[9].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[10].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[11].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[12].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[13].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[14].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[15].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[16].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[17].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[18].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[19].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[20].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[21].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[22].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[23].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[24].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[25].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[26].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[27].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[28].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[29].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[30].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[31].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[32].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[33].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[34].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();
        //theWords[35].text = textFields[GetRandomNumber(1, numberOfWordsUsed)].ToString();

        Debug.Log("The text fields are populated");
    }

    public void RollTheDice_One()
    {
        //rolls the first dice
        int diceRollOne = GetRandomNumber(1, 7);

        print("the first dice rolled " + diceRollOne);

        if(diceRollOne == 1)
        {
            squareHiders[0].SetActive(false);
            squareHiders[6].SetActive(false);
            squareHiders[12].SetActive(false);
            squareHiders[18].SetActive(false);
            squareHiders[24].SetActive(false);
            squareHiders[30].SetActive(false);

            if (!columnOne_Active)
            {
                columnOne_Active = true;
                numOfColumnsActive ++;
            }
        }
        else if (diceRollOne == 2)
        {
            squareHiders[1].SetActive(false);
            squareHiders[7].SetActive(false);
            squareHiders[13].SetActive(false);
            squareHiders[19].SetActive(false);
            squareHiders[25].SetActive(false);
            squareHiders[31].SetActive(false);

            if (!columnTwo_Active)
            {
                columnTwo_Active = true;
                numOfColumnsActive++;
            }
        }
        else if (diceRollOne == 3)
        {
            squareHiders[2].SetActive(false);
            squareHiders[8].SetActive(false);
            squareHiders[14].SetActive(false);
            squareHiders[20].SetActive(false);
            squareHiders[26].SetActive(false);
            squareHiders[32].SetActive(false);

            if (!columnThree_Active)
            {
                columnThree_Active = true;
                numOfColumnsActive++;
            }
        }
        else if (diceRollOne == 4)
        {
            squareHiders[3].SetActive(false);
            squareHiders[9].SetActive(false);
            squareHiders[15].SetActive(false);
            squareHiders[21].SetActive(false);
            squareHiders[27].SetActive(false);
            squareHiders[33].SetActive(false);

            if (!columnFour_Active)
            {
                columnFour_Active = true;
                numOfColumnsActive++;
            }
        }
        else if (diceRollOne == 5)
        {
            squareHiders[4].SetActive(false);
            squareHiders[10].SetActive(false);
            squareHiders[16].SetActive(false);
            squareHiders[22].SetActive(false);
            squareHiders[28].SetActive(false);
            squareHiders[34].SetActive(false);

            if (!columnFive_Active)
            {
                columnFive_Active = true;
                numOfColumnsActive++;
            }
        }
        else if(diceRollOne == 6)
        {
            squareHiders[5].SetActive(false);
            squareHiders[11].SetActive(false);
            squareHiders[17].SetActive(false);
            squareHiders[23].SetActive(false);
            squareHiders[29].SetActive(false);
            squareHiders[35].SetActive(false);

            if (!columnSix_Active)
            {
                columnSix_Active = true;
                numOfColumnsActive++;
            }
        }
        else
        {
            Debug.Log("Error rolling dice one.");
        }
    }

    //public void RollTheDice_Two()
    //{
    //    //rolls the second dice
    //    int diceRollTwo = GetRandomNumber(1, 7);

    //    print("the second dice rolled " + diceRollTwo);

    //    if (diceRollTwo == 1)
    //    {
    //        squareHiders[1].SetActive(false);
    //    }
    //    else if (diceRollTwo == 2)
    //    {
    //        squareHiders[7].SetActive(false);
    //    }
    //    else if (diceRollTwo == 3)
    //    {
    //        squareHiders[13].SetActive(false);
    //    }
    //    else if (diceRollTwo == 4)
    //    {
    //        squareHiders[19].SetActive(false);
    //    }
    //    else if (diceRollTwo == 5)
    //    {
    //        squareHiders[25].SetActive(false);
    //    }
    //    else if (diceRollTwo == 6)
    //    {
    //        squareHiders[31].SetActive(false);
    //    }
    //    else
    //    {
    //        Debug.Log("Error rolling dice two.");
    //    }
    //}

    //public void RollTheDice_Three()
    //{
    //    //rolls the third dice
    //    int diceRollThree = GetRandomNumber(1, 7);

    //    print("the third dice rolled " + diceRollThree);

    //    if (diceRollThree == 1)
    //    {
    //        squareHiders[2].SetActive(false);
    //    }
    //    else if (diceRollThree == 2)
    //    {
    //        squareHiders[8].SetActive(false);
    //    }
    //    else if (diceRollThree == 3)
    //    {
    //        squareHiders[14].SetActive(false);
    //    }
    //    else if (diceRollThree == 4)
    //    {
    //        squareHiders[20].SetActive(false);
    //    }
    //    else if (diceRollThree == 5)
    //    {
    //        squareHiders[26].SetActive(false);
    //    }
    //    else if (diceRollThree == 6)
    //    {
    //        squareHiders[32].SetActive(false);
    //    }
    //    else
    //    {
    //        Debug.Log("Error rolling dice three.");
    //    }
    //}

    //public void RollTheDice_Four()
    //{
    //    //rolls the fourth dice
    //    int diceRollFour = GetRandomNumber(1, 7);

    //    print("the fourth dice rolled " + diceRollFour);

    //    if (diceRollFour == 1)
    //    {
    //        squareHiders[3].SetActive(false);
    //    }
    //    else if (diceRollFour == 2)
    //    {
    //        squareHiders[9].SetActive(false);
    //    }
    //    else if (diceRollFour == 3)
    //    {
    //        squareHiders[15].SetActive(false);
    //    }
    //    else if (diceRollFour == 4)
    //    {
    //        squareHiders[21].SetActive(false);
    //    }
    //    else if (diceRollFour == 5)
    //    {
    //        squareHiders[27].SetActive(false);
    //    }
    //    else if (diceRollFour == 6)
    //    {
    //        squareHiders[33].SetActive(false);
    //    }
    //    else
    //    {
    //        Debug.Log("Error rolling dice four.");
    //    }
    //}

    //public void RollTheDice_Five()
    //{
    //    //rolls the fifth dice
    //    int diceRollFive = GetRandomNumber(1, 7);

    //    print("the fifth dice rolled " + diceRollFive);

    //    if (diceRollFive == 1)
    //    {
    //        squareHiders[4].SetActive(false);
    //    }
    //    else if (diceRollFive == 2)
    //    {
    //        squareHiders[10].SetActive(false);
    //    }
    //    else if (diceRollFive == 3)
    //    {
    //        squareHiders[16].SetActive(false);
    //    }
    //    else if (diceRollFive == 4)
    //    {
    //        squareHiders[22].SetActive(false);
    //    }
    //    else if (diceRollFive == 5)
    //    {
    //        squareHiders[28].SetActive(false);
    //    }
    //    else if (diceRollFive == 6)
    //    {
    //        squareHiders[34].SetActive(false);
    //    }
    //    else
    //    {
    //        Debug.Log("Error rolling dice five.");
    //    }
    //}

    //public void RollTheDice_Six()
    //{
    //    //rolls the sixth dice
    //    int diceRollSix = GetRandomNumber(1, 7);

    //    print("the sixth dice rolled " + diceRollSix);

    //    if (diceRollSix == 1)
    //    {
    //        squareHiders[5].SetActive(false);
    //    }
    //    else if (diceRollSix == 2)
    //    {
    //        squareHiders[11].SetActive(false);
    //    }
    //    else if (diceRollSix == 3)
    //    {
    //        squareHiders[17].SetActive(false);
    //    }
    //    else if (diceRollSix == 4)
    //    {
    //        squareHiders[23].SetActive(false);
    //    }
    //    else if (diceRollSix == 5)
    //    {
    //        squareHiders[29].SetActive(false);
    //    }
    //    else if (diceRollSix == 6)
    //    {
    //        squareHiders[35].SetActive(false);
    //    }
    //    else
    //    {
    //        Debug.Log("Error rolling dice six.");
    //    }
    //}

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

    public void SetSinglePlayer()
    {
        currentGameMode = GameMode.SINGLEPLAYER;
    }

    public void SetMultiPlayer()
    {
        currentGameMode = GameMode.MULTIPLAYER;
    }

    public void AITURN()
    {
        if(columnOne_Active == true && !columnTwo_Active && ! columnThree_Active && !columnFour_Active && !columnFive_Active && !columnSix_Active)
        {
            enemyRollColumnOne();
        }
        else if(columnTwo_Active == true && !columnOne_Active && !columnThree_Active && !columnFour_Active && !columnFive_Active && !columnSix_Active)
        {
            enemyRollColumnTwo();
        }
        else if (columnThree_Active == true && !columnOne_Active && !columnTwo_Active && !columnFour_Active && !columnFive_Active && !columnSix_Active)
        {
            enemyRollColumnThree();
        }
        else if (columnFour_Active == true && !columnOne_Active && !columnThree_Active && !columnTwo_Active && !columnFive_Active && !columnSix_Active)
        {
            enemyRollColumnFour();
        }
        else if (columnFive_Active == true && !columnOne_Active && !columnThree_Active && !columnFour_Active && !columnTwo_Active && !columnSix_Active)
        {
            enemyRollColumnFive();
        }
        else if (columnSix_Active == true && !columnOne_Active && !columnThree_Active && !columnFour_Active && !columnFive_Active && !columnTwo_Active)
        {
            enemyRollColumnSix();
        }

        //Debug.Log(enemyRoll);
    }

    void enemyRollColumnOne()
    {
        enemyRoll = GetRandomNumber(0, 5);

        if (enemyRoll == 0 && alreadySelected[0] == false)
        {
            alreadySelected[0] = true;
            squareSelector[0].SetActive(true);
            squareSelector[0].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[0].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 0 && alreadySelected[0] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }
        

        if (enemyRoll == 1 && alreadySelected[6] == false)
        {
            alreadySelected[6] = true;
            squareSelector[6].SetActive(true);
            squareSelector[6].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[6].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 1 && alreadySelected[6] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }
        

        if (enemyRoll == 2 && alreadySelected[12] == false)
        {
            alreadySelected[12] = true;
            squareSelector[12].SetActive(true);
            squareSelector[12].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[12].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 2 && alreadySelected[12] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }
        

        if (enemyRoll == 3 && alreadySelected[18] == false)
        {
            alreadySelected[18] = true;
            squareSelector[18].SetActive(true);
            squareSelector[18].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[18].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 3 && alreadySelected[18] == false)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }
        

        if (enemyRoll == 4 && alreadySelected[24] == false)
        {
            alreadySelected[24] = true;
            squareSelector[24].SetActive(true);
            squareSelector[24].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[24].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 4 && alreadySelected[24] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }
        

        if (enemyRoll == 5 && alreadySelected[30] == false)
        {
            alreadySelected[30] = true;
            squareSelector[30].SetActive(true);
            squareSelector[30].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[30].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 5 && alreadySelected[30] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        //if there is only one remaining square
        else
        {
            if(alreadySelected[0] && alreadySelected[6] && alreadySelected[12] && alreadySelected[18] && alreadySelected[24])
            {
                alreadySelected[30] = true;
                squareSelector[30].SetActive(true);
                squareSelector[30].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[30].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[0] && alreadySelected[6] && alreadySelected[12] && alreadySelected[18] && alreadySelected[30])
            {
                alreadySelected[24] = true;
                squareSelector[24].SetActive(true);
                squareSelector[24].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[24].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[0] && alreadySelected[6] && alreadySelected[12] && alreadySelected[24] && alreadySelected[30])
            {
                alreadySelected[18] = true;
                squareSelector[18].SetActive(true);
                squareSelector[18].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[18].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[0] && alreadySelected[6] && alreadySelected[18] && alreadySelected[24] && alreadySelected[30])
            {
                alreadySelected[12] = true;
                squareSelector[12].SetActive(true);
                squareSelector[12].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[12].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[0] && alreadySelected[12] && alreadySelected[18] && alreadySelected[24] && alreadySelected[30])
            {
                alreadySelected[6] = true;
                squareSelector[6].SetActive(true);
                squareSelector[6].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[6].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[6] && alreadySelected[12] && alreadySelected[18] && alreadySelected[24] && alreadySelected[30])
            {
                alreadySelected[0] = true;
                squareSelector[0].SetActive(true);
                squareSelector[0].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[0].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else
            {
                Debug.Log("Error for AI rolling in column one");
            }
        }

        Debug.Log(enemyRoll);
    }
    void enemyRollColumnTwo()
    {
        enemyRoll = GetRandomNumber(6, 11);

        if (enemyRoll == 6 && alreadySelected[1] == false)
        {
            alreadySelected[1] = true;
            squareSelector[1].SetActive(true);
            squareSelector[1].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[1].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 6 && alreadySelected[1] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 7 && alreadySelected[7] == false)
        {
            alreadySelected[7] = true;
            squareSelector[7].SetActive(true);
            squareSelector[7].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[7].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 7 && alreadySelected[7] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 8 && alreadySelected[13] == false)
        {
            alreadySelected[13] = true;
            squareSelector[13].SetActive(true);
            squareSelector[13].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[13].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 8 && alreadySelected[13] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 9 && alreadySelected[19] == false)
        {
            alreadySelected[19] = true;
            squareSelector[19].SetActive(true);
            squareSelector[19].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[19].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 9 && alreadySelected[19] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 10 && alreadySelected[25] == false)
        {
            alreadySelected[25] = true;
            squareSelector[25].SetActive(true);
            squareSelector[25].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[25].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 10 && alreadySelected[25] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 11 && alreadySelected[31] == false)
        {
            alreadySelected[31] = true;
            squareSelector[31].SetActive(true);
            squareSelector[31].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[31].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 11 && alreadySelected[31] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        else
        {
            if (alreadySelected[1] && alreadySelected[7] && alreadySelected[13] && alreadySelected[19] && alreadySelected[25])
            {
                alreadySelected[31] = true;
                squareSelector[31].SetActive(true);
                squareSelector[31].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[31].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[1] && alreadySelected[7] && alreadySelected[13] && alreadySelected[19] && alreadySelected[31])
            {
                alreadySelected[25] = true;
                squareSelector[25].SetActive(true);
                squareSelector[25].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[25].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[1] && alreadySelected[7] && alreadySelected[13] && alreadySelected[25] && alreadySelected[31])
            {
                alreadySelected[19] = true;
                squareSelector[19].SetActive(true);
                squareSelector[19].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[19].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[1] && alreadySelected[7] && alreadySelected[19] && alreadySelected[25] && alreadySelected[31])
            {
                alreadySelected[13] = true;
                squareSelector[13].SetActive(true);
                squareSelector[13].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[13].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[1] && alreadySelected[13] && alreadySelected[19] && alreadySelected[25] && alreadySelected[31])
            {
                alreadySelected[7] = true;
                squareSelector[7].SetActive(true);
                squareSelector[7].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[7].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[7] && alreadySelected[13] && alreadySelected[19] && alreadySelected[25] && alreadySelected[31])
            {
                alreadySelected[1] = true;
                squareSelector[1].SetActive(true);
                squareSelector[1].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[1].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }

            else
            {
                Debug.Log("Error for AI rolling in column two");
            }
        }


        Debug.Log(enemyRoll);
    }
    void enemyRollColumnThree()
    {
        enemyRoll = GetRandomNumber(12, 17);

        if (enemyRoll == 12 && alreadySelected[2] == false)
        {
            alreadySelected[2] = true;
            squareSelector[2].SetActive(true);
            squareSelector[2].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[2].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 12 && alreadySelected[2] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 13 && alreadySelected[8] == false)
        {
            alreadySelected[8] = true;
            squareSelector[8].SetActive(true);
            squareSelector[8].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[8].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 13 && alreadySelected[8] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 14 && alreadySelected[14] == false)
        {
            alreadySelected[14] = true;
            squareSelector[14].SetActive(true);
            squareSelector[14].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[14].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 14 && alreadySelected[14] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 15 && alreadySelected[20] == false)
        {
            alreadySelected[20] = true;
            squareSelector[20].SetActive(true);
            squareSelector[20].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[20].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 15 && alreadySelected[20] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 16 && alreadySelected[26] == false)
        {
            alreadySelected[26] = true;
            squareSelector[26].SetActive(true);
            squareSelector[26].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[26].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 16 && alreadySelected[26] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 17 && alreadySelected[32] == false)
        {
            alreadySelected[32] = true;
            squareSelector[32].SetActive(true);
            squareSelector[32].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[32].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 17 && alreadySelected[32] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        else
        {
            if(alreadySelected[2] && alreadySelected[8] && alreadySelected[14] && alreadySelected[20] && alreadySelected[26])
            {
                alreadySelected[32] = true;
                squareSelector[32].SetActive(true);
                squareSelector[32].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[32].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[2] && alreadySelected[8] && alreadySelected[14] && alreadySelected[20] && alreadySelected[32])
            {
                alreadySelected[26] = true;
                squareSelector[26].SetActive(true);
                squareSelector[26].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[26].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[2] && alreadySelected[8] && alreadySelected[14] && alreadySelected[26] && alreadySelected[32])
            {
                alreadySelected[20] = true;
                squareSelector[20].SetActive(true);
                squareSelector[20].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[20].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[2] && alreadySelected[8] && alreadySelected[20] && alreadySelected[26] && alreadySelected[32])
            {
                alreadySelected[14] = true;
                squareSelector[14].SetActive(true);
                squareSelector[14].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[14].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[2] && alreadySelected[14] && alreadySelected[20] && alreadySelected[26] && alreadySelected[32])
            {
                alreadySelected[8] = true;
                squareSelector[8].SetActive(true);
                squareSelector[8].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[8].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[8] && alreadySelected[14] && alreadySelected[20] && alreadySelected[26] && alreadySelected[32])
            {
                alreadySelected[2] = true;
                squareSelector[2].SetActive(true);
                squareSelector[2].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[2].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }

            else
            {
                Debug.Log("Error for AI rolling in column three");
            }
        }

        Debug.Log(enemyRoll);
    }
    void enemyRollColumnFour()
    {
        enemyRoll = GetRandomNumber(18, 23);

        if (enemyRoll == 18 && alreadySelected[3] == false)
        {
            alreadySelected[3] = true;
            squareSelector[3].SetActive(true);
            squareSelector[3].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[3].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 18 && alreadySelected[3] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 19 && alreadySelected[9] == false)
        {
            alreadySelected[9] = true;
            squareSelector[9].SetActive(true);
            squareSelector[9].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[9].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 19 && alreadySelected[9] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 20 && alreadySelected[15] == false)
        {
            alreadySelected[15] = true;
            squareSelector[15].SetActive(true);
            squareSelector[15].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[15].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 20 && alreadySelected[15] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }
        

        if (enemyRoll == 21 && alreadySelected[21] == false)
        {
            alreadySelected[21] = true;
            squareSelector[21].SetActive(true);
            squareSelector[21].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[21].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 21 && alreadySelected[21] == true)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 22 && alreadySelected[27] == false)
        {
            alreadySelected[27] = true;
            squareSelector[27].SetActive(true);
            squareSelector[27].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[27].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 22 && alreadySelected[27] == false)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 23 && alreadySelected[33] == false)
        {
            alreadySelected[33] = true;
            squareSelector[33].SetActive(true);
            squareSelector[33].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[33].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        if (enemyRoll == 23 && alreadySelected[33] == false)
        {
            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        else
        {
            if (alreadySelected[3] && alreadySelected[9] && alreadySelected[15] && alreadySelected[21] && alreadySelected[27])
            {
                alreadySelected[33] = true;
                squareSelector[33].SetActive(true);
                squareSelector[33].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[33].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[3] && alreadySelected[9] && alreadySelected[15] && alreadySelected[21] && alreadySelected[33])
            {
                alreadySelected[27] = true;
                squareSelector[27].SetActive(true);
                squareSelector[27].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[27].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[3] && alreadySelected[9] && alreadySelected[15] && alreadySelected[27] && alreadySelected[33])
            {
                alreadySelected[21] = true;
                squareSelector[21].SetActive(true);
                squareSelector[21].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[21].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[3] && alreadySelected[9] && alreadySelected[21] && alreadySelected[27] && alreadySelected[33])
            {
                alreadySelected[15] = true;
                squareSelector[15].SetActive(true);
                squareSelector[15].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[15].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[3] && alreadySelected[15] && alreadySelected[21] && alreadySelected[27] && alreadySelected[33])
            {
                alreadySelected[9] = true;
                squareSelector[9].SetActive(true);
                squareSelector[9].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[9].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[9] && alreadySelected[15] && alreadySelected[21] && alreadySelected[27] && alreadySelected[33])
            {
                alreadySelected[3] = true;
                squareSelector[3].SetActive(true);
                squareSelector[3].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[3].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }

            else
            {
                Debug.Log("Error for AI rolling in column four");
            }
        }

        Debug.Log(enemyRoll);
    }
    void enemyRollColumnFive()
    {
        enemyRoll = GetRandomNumber(24, 29);

        if (enemyRoll == 24 && alreadySelected[4] == false)
        {
            alreadySelected[4] = true;
            squareSelector[4].SetActive(true);
            squareSelector[4].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[4].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if (enemyRoll == 24 && alreadySelected[4] == true)
        {
            enemyRoll = GetRandomNumber(25, 29);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 25 && alreadySelected[10] == false)
        {
            alreadySelected[10] = true;
            squareSelector[10].SetActive(true);
            squareSelector[10].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[10].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 25 && alreadySelected[10] == true)
        {
            enemyRoll = GetRandomNumber(26, 29);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 26 && alreadySelected[16] == false)
        {
            alreadySelected[16] = true;
            squareSelector[16].SetActive(true);
            squareSelector[16].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[16].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 26 && alreadySelected[16] == true)
        {
            enemyRoll = GetRandomNumber(27, 29);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 27 && alreadySelected[22] == false)
        {
            alreadySelected[22] = true;
            squareSelector[22].SetActive(true);
            squareSelector[22].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[22].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 27 && alreadySelected[22] == true)
        {
            enemyRoll = GetRandomNumber(24, 27);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 28 && alreadySelected[28] == false)
        {
            enemyRoll = GetRandomNumber(29, 29);

            alreadySelected[28] = true;
            squareSelector[28].SetActive(true);
            squareSelector[28].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[28].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 28 && alreadySelected[28] == true)
        {
            enemyRoll = GetRandomNumber(25, 27);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 29 && alreadySelected[34] == false)
        {
            alreadySelected[34] = true;
            squareSelector[34].SetActive(true);
            squareSelector[34].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[34].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 29 && alreadySelected[34] == true)
        {
            enemyRoll = GetRandomNumber(24, 28);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        else
        {
            if (alreadySelected[4] && alreadySelected[10] && alreadySelected[16] && alreadySelected[22] && alreadySelected[28])
            {
                alreadySelected[34] = true;
                squareSelector[34].SetActive(true);
                squareSelector[34].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[34].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[4] && alreadySelected[10] && alreadySelected[16] && alreadySelected[22] && alreadySelected[34])
            {
                alreadySelected[28] = true;
                squareSelector[28].SetActive(true);
                squareSelector[28].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[28].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[4] && alreadySelected[10] && alreadySelected[16] && alreadySelected[28] && alreadySelected[34])
            {
                alreadySelected[22] = true;
                squareSelector[22].SetActive(true);
                squareSelector[22].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[22].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[4] && alreadySelected[10] && alreadySelected[22] && alreadySelected[28] && alreadySelected[34])
            {
                alreadySelected[16] = true;
                squareSelector[16].SetActive(true);
                squareSelector[16].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[16].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[4] && alreadySelected[16] && alreadySelected[22] && alreadySelected[28] && alreadySelected[34])
            {
                alreadySelected[10] = true;
                squareSelector[10].SetActive(true);
                squareSelector[10].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[10].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[10] && alreadySelected[16] && alreadySelected[22] && alreadySelected[28] && alreadySelected[34])
            {
                alreadySelected[4] = true;
                squareSelector[4].SetActive(true);
                squareSelector[4].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[4].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }

            //else
            //{
            //    Debug.Log("Error for AI rolling in column five");
            //}
        }

        Debug.Log(enemyRoll);
    }
    void enemyRollColumnSix()
    {
        enemyRoll = GetRandomNumber(30, 35);

        if (enemyRoll == 30 && alreadySelected[5] == false)
        {
            alreadySelected[5] = true;
            squareSelector[5].SetActive(true);
            squareSelector[5].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[5].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 30 && alreadySelected[5] == true)
        {
            enemyRoll = GetRandomNumber(31, 35);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 31 && alreadySelected[11] == false)
        {
            alreadySelected[11] = true;
            squareSelector[11].SetActive(true);
            squareSelector[11].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[11].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 31 && alreadySelected[11] == true)
        {
            enemyRoll = GetRandomNumber(32, 35);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 32 && alreadySelected[17] == false)
        {
            alreadySelected[17] = true;
            squareSelector[17].SetActive(true);
            squareSelector[17].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[17].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 32 && alreadySelected[17] == true)
        {
            enemyRoll = GetRandomNumber(33, 35);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 33 && alreadySelected[23] == false)
        {
            alreadySelected[23] = true;
            squareSelector[23].SetActive(true);
            squareSelector[23].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[23].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 33 && alreadySelected[23] == true)
        {
            enemyRoll = GetRandomNumber(34, 35);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 34 && alreadySelected[29] == false)
        {
            alreadySelected[29] = true;
            squareSelector[29].SetActive(true);
            squareSelector[29].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[29].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 34 && alreadySelected[29] == true)
        {
            enemyRoll = GetRandomNumber(30, 33);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        if (enemyRoll == 35 && alreadySelected[35] == false)
        {
            alreadySelected[35] = true;
            squareSelector[35].SetActive(true);
            squareSelector[35].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
            squareSelector[35].GetComponent<Image>().color = aiSelect_Color;

            aiTurnSuccess = true;
        }
        else if(enemyRoll == 35 && alreadySelected[35] == true)
        {
            enemyRoll = GetRandomNumber(30, 34);

            Debug.Log("AI is re-rolling because it selected a taken tile");
            //AITURN();
        }


        else
        {
            if (alreadySelected[5] && alreadySelected[11] && alreadySelected[17] && alreadySelected[23] && alreadySelected[29])
            {
                alreadySelected[35] = true;
                squareSelector[35].SetActive(true);
                squareSelector[35].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[35].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[5] && alreadySelected[11] && alreadySelected[17] && alreadySelected[23] && alreadySelected[35])
            {
                alreadySelected[29] = true;
                squareSelector[29].SetActive(true);
                squareSelector[29].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[29].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[5] && alreadySelected[11] && alreadySelected[17] && alreadySelected[29] && alreadySelected[35])
            {
                alreadySelected[23] = true;
                squareSelector[23].SetActive(true);
                squareSelector[23].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[23].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[5] && alreadySelected[11] && alreadySelected[23] && alreadySelected[29] && alreadySelected[35])
            {
                alreadySelected[17] = true;
                squareSelector[17].SetActive(true);
                squareSelector[17].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[17].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[5] && alreadySelected[17] && alreadySelected[23] && alreadySelected[29] && alreadySelected[35])
            {
                alreadySelected[11] = true;
                squareSelector[11].SetActive(true);
                squareSelector[11].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[11].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }
            else if (alreadySelected[11] && alreadySelected[17] && alreadySelected[23] && alreadySelected[29] && alreadySelected[35])
            {
                alreadySelected[5] = true;
                squareSelector[5].SetActive(true);
                squareSelector[5].GetComponentInParent<UnityEngine.UI.Button>().enabled = false;
                squareSelector[5].GetComponent<Image>().color = aiSelect_Color;

                aiTurnSuccess = true;
            }

            //else
            //{
            //    Debug.Log("Error for AI rolling in column six");
            //}
        }

        Debug.Log(enemyRoll);
    }

    public void RemoveButtonA1()
    {
        alreadySelected[0] = true;
    }

    public void RemoveButtonA2()
    {
        alreadySelected[6] = true;
    }

    public void RemoveButtonA3()
    {
        alreadySelected[12] = true;
    }

    public void RemoveButtonA4()
    {
        alreadySelected[18] = true;
    }

    public void RemoveButtonA5()
    {
        alreadySelected[24] = true;
    }

    public void RemoveButtonA6()
    {
        alreadySelected[30] = true;
    }

    public void RemoveButtonB1()
    {
        alreadySelected[1] = true;
    }

    public void RemoveButtonB2()
    {
        alreadySelected[7] = true;
    }

    public void RemoveButtonB3()
    {
        alreadySelected[13] = true;
    }

    public void RemoveButtonB4()
    {
        alreadySelected[19] = true;
    }

    public void RemoveButtonB5()
    {
        alreadySelected[25] = true;
    }

    public void RemoveButtonB6()
    {
        alreadySelected[31] = true;
    }

    public void RemoveButtonC1()
    {
        alreadySelected[2] = true;
    }

    public void RemoveButtonC2()
    {
        alreadySelected[8] = true;
    }

    public void RemoveButtonC3()
    {
        alreadySelected[14] = true;
    }

    public void RemoveButtonC4()
    {
        alreadySelected[20] = true;
    }

    public void RemoveButtonC5()
    {
        alreadySelected[26] = true;
    }

    public void RemoveButtonC6()
    {
        alreadySelected[32] = true;
    }

    public void RemoveButtonD1()
    {
        alreadySelected[3] = true;
    }

    public void RemoveButtonD2()
    {
        alreadySelected[9] = true;
    }

    public void RemoveButtonD3()
    {
        alreadySelected[15] = true;
    }

    public void RemoveButtonD4()
    {
        alreadySelected[21] = true;
    }

    public void RemoveButtonD5()
    {
        alreadySelected[27] = true;
    }

    public void RemoveButtonD6()
    {
        alreadySelected[33] = true;
    }

    public void RemoveButtonE1()
    {
        alreadySelected[4] = true;
    }

    public void RemoveButtonE2()
    {
        alreadySelected[10] = true;
    }

    public void RemoveButtonE3()
    {
        alreadySelected[16] = true;
    }

    public void RemoveButtonE4()
    {
        alreadySelected[22] = true;
    }

    public void RemoveButtonE5()
    {
        alreadySelected[28] = true;
    }

    public void RemoveButtonE6()
    {
        alreadySelected[34] = true;
    }

    public void RemoveButtonF1()
    {
        alreadySelected[5] = true;
    }

    public void RemoveButtonF2()
    {
        alreadySelected[11] = true;
    }

    public void RemoveButtonF3()
    {
        alreadySelected[17] = true;
    }

    public void RemoveButtonF4()
    {
        alreadySelected[23] = true;
    }

    public void RemoveButtonF5()
    {
        alreadySelected[29] = true;
    }

    public void RemoveButtonF6()
    {
        alreadySelected[35] = true;
    }
}
