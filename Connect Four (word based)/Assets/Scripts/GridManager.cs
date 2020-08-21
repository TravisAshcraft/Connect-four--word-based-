using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int rows = 6;
    [SerializeField] int columns = 7;
    [SerializeField] float tileSize = 1;


    // Start is called before the first frame update
    void Start()
    {
        
        for (int row = 0; row < rows; row++)
        {
            for (int cols = 0; cols < columns; cols++)
            {
                GameObject tile = (GameObject)Instantiate(Resources.Load("blankTile"));
                

                float posX = cols * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
