using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTile : MonoBehaviour
{
    public GameObject tileSelector;

    public Button button;

    private void Start()
    {
        tileSelector.SetActive(false);
    }

    public void RevealSelector()
    {
        tileSelector.SetActive(true);

        button.enabled = false;
    }
}
