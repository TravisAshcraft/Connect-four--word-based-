using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordCollector : MonoBehaviour
{
    [SerializeField] Button playButton;

    public string words;
    public GameObject inputField;
    public InputField eraseField;
    public TMP_Text text;
    public int wordCount;
    public bool testForPlay = false;
    private List<string> wordList = new List<string>();

    private void Start()
    {
        wordCount = 0;
        
    }

    public void Update()
    {
        updateCounter();
    }

    public void StoreName() //stores the words into a List
    {
        words = inputField.GetComponent<Text>().text; //creates words variable using the inputField
        wordList.Add(words);// adds the word to the list
        if(words != "")// increments the counter by one
        {
            wordCount++;
        }
         
        eraseField.text = ""; // erases the word after each add
        
        Debug.Log(words);
    }

    public void updateCounter() // updates the counter
    {
        text.SetText(wordCount+"/36 words");
        
    }

    public void randomizeData()// Sets the words at random using a for loop
    {
        for (int i = 0; i < wordList.Count; i++)
        {
            string temp = wordList[i];
            int randomIndex = UnityEngine.Random.Range(i, wordList.Count);
            wordList[i] = wordList[randomIndex];
            wordList[randomIndex] = temp;
        }
    }

    public void SaveWords()// saves the words and allows the player to select play
    {
        if (wordCount > 6)
        {
            bool testForPlay = true;

            if (testForPlay)
            {
                playButton.interactable = true;
                playButton.onClick.AddListener(BeginGame);
            }
        }
        
        
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
}
