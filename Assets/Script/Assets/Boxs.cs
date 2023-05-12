using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxs : MonoBehaviour
{
    public Box[] Allboxes;

    public GameObject[] blockline;

    private Transform player;

    public Vector2 positionRange;

    public GameObject boxsGroup;

   // public int Length { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        SetBox();
        
    }

  
    
    void SetBox()
    {
        for(int i = 0; i< Allboxes.Length; i++)
        {
            Allboxes[i].SetAmount();
        }
        for (int i = 0; i < blockline.Length; i++)
        {
            bool randomBool = Random.value > 0.5f;
            blockline[i].SetActive(randomBool);
        }
        //DecreaseDifficulty();
    }
    void Reposition()
    {
        int boxsAmount = FindObjectsOfType<Boxs>().Length;
      

        transform.position = new Vector2(0, player.position.y + (LevelController.instance.blockLineDistance * (boxsAmount -1 )));

        boxsGroup.transform.localPosition = new Vector2(0, Random.Range(positionRange.x, positionRange.y));
    }
    //void DecreaseDifficulty()
    //{


    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Reposition();
            SetBox();
        }
    }

}
