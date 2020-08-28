using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject settings;
    [SerializeField] GameObject wordsCont;
    [SerializeField] Button playBtn;
    [SerializeField] Button settingsBtn;
    [SerializeField] Button saveBtn;
    [SerializeField] Button closeBtn;

    [SerializeField] TMP_InputField[] words;
    WordCollector wordCollector;
 

   /* void Start()
    {
        settingsBtn.onClick.AddListener(BringSettings);
        data = FindObjectOfType<WordData>();
    }

    void BeginGame()
    {
        SceneManager.LoadScene("Game");
        
    }

    void BringSettings()
    {
        settings.SetActive(true);
        saveBtn.onClick.AddListener(SaveSettings);
        closeBtn.onClick.AddListener(CloseSettings);
    }

    void CloseSettings()
    {
        settings.SetActive(false);
    }

    public void SaveSettings()
    {
        List<string> list = new List<string>();
        bool test = true;
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].text == "")
            {
                test = false;
            }
            else
            {
                list.Add(words[i].text);
            }
        }
        if (test)
        {
            data.updateData(list);
            playBtn.interactable = true;
            playBtn.onClick.AddListener(BeginGame);
            CloseSettings();
        }
    }*/
}

    

