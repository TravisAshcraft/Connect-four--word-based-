using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Button singlePlayerButton;
    [SerializeField] Button multiplayerButton;
    [SerializeField] GameObject transition;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSinglePlayer()
    {
        StartCoroutine(TransitionSinglScene());
    }

    public void LoadMultiPlayer()
    {
        StartCoroutine(TransitionMultiScene());
    }

    IEnumerator TransitionSinglScene()
    {
        //transition scene 
        Animator animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("LoadScene");
    
        //wait for x seconds
        yield return new WaitForSeconds(3);

        //load new scene
        SceneManager.LoadScene("SinglePlayer");

    }

    IEnumerator TransitionMultiScene()
    {
        //transition scene 
        Animator animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("LoadScene");

        //wait for x seconds
        yield return new WaitForSeconds(3);

        //load new scene
        SceneManager.LoadScene("Multiplayer");

    }

    //public void WhoWonMatch()
    //{
    //if(playerOne has more than four tiles selected){
    //      playerOne wins the Match and is given an icon e.g.(WinIcon.SetActive(True));
    //      scoreCounter++;
    //}
    //else if(playerTwo has more than four tiles selected){
    //      playerTwo wins the Match and is given an icon e.g.(WinIcon.SetActive(True));
    //      scoreCounter++;
    //}
    //}

    //public void GameWinner(){
    //      if(playerOne.scoreCounter > 2){
    //          StartCoroutine(Winnner);
    //      }
    //      else if(playerTwo.scoreCounter > 2){
    //          StartCoroutine(Loser);
    //      }

}
