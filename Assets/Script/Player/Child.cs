using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Child : MonoBehaviour
{
    public Text amountText;

    public GameObject childPrefab;

    private int amount;

    private void OnEnable()
    {
        amount = Random.Range(1, 6);
        amountText.text = amount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            for(int i = 0; i< amount; i++)
            {
                int index = other.transform.childCount;
                GameObject newChild = Instantiate(childPrefab, other.transform);
                newChild.transform.localPosition = new Vector3(0, -index, 0);

                FollowPlayer followPlayer = newChild.GetComponent<FollowPlayer>();

                if(followPlayer != null)
                {
                    followPlayer.target = other.transform.GetChild(index - 1);
                }    
            }

            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.SetText(player.transform.childCount);
            }

           
        }
        gameObject.SetActive(false);
    }
}
