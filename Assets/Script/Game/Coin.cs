using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio1FoodCollect);
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.SetTextCoin(1);
            }
        }
        gameObject.SetActive(false);
    }
}