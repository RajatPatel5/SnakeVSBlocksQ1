using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Child : MonoBehaviour
{
    public Text amountText;

 

    private int amount ;

 


    private void Awake()
    {
       
    }

    private void OnEnable()
    {
        amount = Random.Range(1, 6);
        amountText.text = amount.ToString();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio1FoodCollect);
            for (int i = 0; i < amount; i++)
            {
              
                    FollowPlayer followPlayer = other.GetComponent<FollowPlayer>();
                if (followPlayer != null)
                {
                    followPlayer.AddTail();
                }
              //  player.GetComponent<FollowPlayer>().AddTail();
                //    int index = other.transform.childCount;
                //    GameObject newChild = Instantiate(childPrefab, other.transform);
                //    newChild.transform.localPosition = new Vector3(0, -index-0.1f, 0);
                    
                 //  followPlayer.GetComponent<FollowPlayer>().AddTail();

              //   if(followPlayer != null)
                //    {
                //        followPlayer.target = other.transform.GetChild(index - 1);
                //    }    
                //}

                Player player = other.GetComponent<Player>();
                if(player != null)
                {
                    player.SetText(player.transform.childCount);
                 }
            }


            }
        gameObject.SetActive(false);
    }
}
