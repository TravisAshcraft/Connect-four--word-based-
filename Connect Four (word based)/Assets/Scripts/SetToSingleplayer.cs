using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToSingleplayer : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManger>().SetSinglePlayer();  
    }
}
