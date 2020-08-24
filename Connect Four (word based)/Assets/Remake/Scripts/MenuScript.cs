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
    [SerializeField] GameObject menuTitle;
    [SerializeField] GameObject transistionCirle;
    [SerializeField] Button playBtn;
    [SerializeField] Button settingsBtn;
    [SerializeField] Button saveBtn;
    [SerializeField] Button closeBtn;

    

    void Start()
    {
        settingsBtn.onClick.AddListener(BringSettings);
        GameStartAnims();
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

    void SaveSettings()
    {
        bool test = true;
        Test[] words = wordsCont.GetComponentsInChildren<Test>();
        for (int i = 0; i < words.Length; i++)
        {
            Debug.Log(words[i].gameObject.name);
        }
        playBtn.interactable = true;
        //playBtn.onClick.AddListener(BeginGame);
    }

   // public void BeginGame()
   // {
     //   SceneManager.LoadScene("Game");
    //}

    public void GameStartAnims()
    {
        Animator animator = menuTitle.GetComponent<Animator>();
        animator.SetTrigger("wiggle");
    }

    
}
