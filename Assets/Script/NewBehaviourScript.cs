using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateBoard()
    {
        for(int file = 0;file <8; file++)
        {
            for (int rank = 0; rank <8; rank++)
            {
                bool isLight = (file + rank) % 2 != 0;

                var position = new Vector2(-3.5f + file, -3.5f + rank);

             
            }
        }
    }
}
