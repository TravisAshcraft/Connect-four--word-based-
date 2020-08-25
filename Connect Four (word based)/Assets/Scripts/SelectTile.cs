using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTile : MonoBehaviour
{
    GameManger gameManager;

    public GameObject tileSelector;

    public Button button;

    public Color[] whoSelected;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManger>();
        tileSelector.SetActive(false);
    }

    public void RevealSelector()
    {
        if(gameManager.CurrentTurn == GameManger.CurrentPlayerTurn.PLAYER_ONE)
        {
            tileSelector.SetActive(true);
            tileSelector.GetComponent<Image>().color = whoSelected[0];
            button.enabled = false;

            gameManager.ChangeTurns();
        }
        else if(gameManager.CurrentTurn == GameManger.CurrentPlayerTurn.PLAYER_TWO)
        {
            tileSelector.SetActive(true);
            tileSelector.GetComponent<Image>().color = whoSelected[1];
            button.enabled = false;

            gameManager.ChangeTurns();
        }
        else
        {
            Debug.Log("Error! Currently it is neither player's turn.");
        }
    }
}
