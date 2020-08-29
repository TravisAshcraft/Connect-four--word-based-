using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordPool : MonoBehaviour
{
    public List<string> inputWords = new List<string>();

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
