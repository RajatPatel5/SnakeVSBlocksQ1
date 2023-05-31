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

    public void Start()
    {
        player = FindObjectOfType<Player>().transform;
        SetBox();
        for (int i = 0; i < blockline.Length; i++)
        {
            blockline[i].SetActive(false);
        }


    }

    public void SetBox()
    {
        for (int i = 0; i < Allboxes.Length; i++)
        {
            Allboxes[i].SetAmount();
        }
        for (int i = 0; i < blockline.Length; i++)
        {
            bool randomBool = Random.value > 0.5f;
            blockline[i].SetActive(randomBool);
        }

    }

    public void Reposition()
    {
        int boxsAmount = FindObjectsOfType<Boxs>().Length;

        transform.position = new Vector2(0, player.position.y + (LevelController.instance.blockLineDistance * (boxsAmount - 1)));
        boxsGroup.transform.localPosition = new Vector2(0, Random.Range(positionRange.x, positionRange.y));
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Reposition();
            SetBox();
        }
    }

}
