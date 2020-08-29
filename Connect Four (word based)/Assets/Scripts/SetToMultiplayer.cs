using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToMultiplayer : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManger>().SetMultiPlayer();
    }
}
