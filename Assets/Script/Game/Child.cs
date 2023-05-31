using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Child : MonoBehaviour
{
    public Text amountText;
    private int amount ;

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
