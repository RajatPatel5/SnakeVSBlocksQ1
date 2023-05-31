using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOutfit : MonoBehaviour
{
    public SpriteRenderer sprite;
    public SpriteRenderer sprite1;
    public Image sprite2;
    public Image Player;

   
   

    public Sprite[] newSprite;

    private void Start()
    {
       
    }

    private void Update()
    {
        ChangeOutfit();
    }

    public void ChangeOutfit()
    {
        sprite1.sprite = sprite.sprite;
        sprite2.sprite = sprite.sprite;
        Player.sprite = sprite.sprite;
        sprite1.color = sprite.color;
        sprite2.color = sprite.color;
        Player.color = sprite.color;
    }
    public void YellowColor()
    {
        sprite.sprite = newSprite[0];
       
       
        sprite.color = Color.yellow;
      
      
        
    }
    public void GreenColor()
    {
        sprite.sprite = newSprite[0];
       
      
        sprite.color = Color.green;
      
    }
    public void BlueColor()
    {
        sprite.sprite = newSprite[0];
      
      
        sprite.color = Color.blue;
      
       
    }
    public void RedColor()
    {
        sprite.sprite = newSprite[0];
       
        sprite.color = Color.red;
      
    }

    public void ChangeSprite8()
    {
        sprite.sprite = newSprite[8];
      
        sprite.color = Color.white;
      
    }
   public void ChangeSprite1()
    {
        sprite.sprite = newSprite[1];
     
        sprite.color = Color.white;
       
    }
   public void ChangeSprite2()
    {
        sprite.sprite = newSprite[2];
      
        sprite.color = Color.white;
       
    }
   public void ChangeSprite3()
    {
        sprite.sprite = newSprite[3];
      
        sprite.color = Color.white;
      
    }
    public void ChangeSprite4()
    {
        sprite.sprite = newSprite[4];
       
        sprite.color = Color.white;
      
    }
    public void ChangeSprite5()
    {
        sprite.sprite = newSprite[5];
      
        sprite.color = Color.white;
       
    }
    public void ChangeSprite6()
    {
        sprite.sprite = newSprite[6];
     
        sprite.color = Color.white;
       
    }
    public void ChangeSprite7()
    {
        sprite.sprite = newSprite[7];
      
        sprite.color = Color.white;
      
    }
}
