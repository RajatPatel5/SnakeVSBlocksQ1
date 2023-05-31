using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopButton : MonoBehaviour
{
    public Text price;
    public Image sprite;
    public Sprite sprite1;
    public Text Balance;
    public int value;
    public Text Coins;
    //public ParticleSystem Effect;
    public SpriteRenderer spritePlayer;
    public SpriteRenderer spriteChild;
    public Image spriteOutfit;
    public Image PlayerMain;
    public Image skin;
    //public Image border;
  //  bool bord = true;
    public void Start()
    {
        Balance.enabled = false;
        price.text = value.ToString();
        //border.enabled = false;

        spriteChild.sprite = spritePlayer.sprite;
        spriteOutfit.sprite = spritePlayer.sprite;
        PlayerMain.sprite = spritePlayer.sprite;
    }


    public void ButtonClick()
    {
       

        int P = int.Parse(price.text);
        int C = int.Parse(Coins.text);
        if (C >= P)
        {
           // border.enabled = true;
            //gameObject.transform.position = Effect.transform.position;
            //Effect.Play();
            sprite.sprite = sprite1;
            spritePlayer.sprite = sprite.sprite;
            spriteChild.sprite = sprite.sprite;
            spriteOutfit.sprite = sprite.sprite;
            PlayerMain.sprite = sprite.sprite;

            C -= P;
            price.text = "0";
            Coins.text = C.ToString();
            skin.enabled = false;
        }
        else
        {
            // Balance.enabled = true;
           
                Balance.enabled = true;
            StartCoroutine(ShowMessageCoroutine());
          
        }

    }
    IEnumerator ShowMessageCoroutine()
    {
        //Wait for 5 seconds
        yield return new WaitForSecondsRealtime(0.5f);
        Balance.enabled = false;
    }
}