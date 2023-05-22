using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float mouseDistance;

    private Rigidbody2D rb;

    private bool sliding;

    private int dir;
 
    public Text childText;

    public GameObject prefab;
    public Transform Point;

    public float speed = 5;


    public GameObject Prefab;


    private float deltaX, deltaY;

 
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();

        
    }


   
    void Update()
    {
        
      

    }

    private void FixedUpdate()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
          
              switch(touch.phase)
             {
          
                case TouchPhase.Moved:
                 deltaX = touchPos.x;
                   break;
              }
        }


        
       

            mouseDistance = deltaX - transform.position.x;

            if (LevelController.instance.gameOver)
                  rb.velocity = Vector2.zero;
              

           else if (!sliding)
                rb.velocity = new Vector2(mouseDistance * speed, LevelController.instance.gameSpeed * LevelController.instance.multiplier);
            else
                rb.velocity = new Vector2(dir * 2.5f, LevelController.instance.gameSpeed * LevelController.instance.multiplier);

     

    }

    public void SetText(int amount)
    {
        childText.text = amount.ToString();
    }

    public void TackDamage()
    {
        if (LevelController.instance.gameOver)
             return;
           
        int children = transform.childCount;
        if(children <= 1)
        {
            LevelController.instance.GameOver();
        }
        else
        {
          
           
            FollowPlayer followPlayer = GetComponent<FollowPlayer>();
            followPlayer.Delete();
            Destroy(transform.GetChild(children-1).gameObject);
            LevelController.instance.Score(1);
            AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio2BlockHit);
            Instantiate(prefab, Point.transform.position, Quaternion.identity);
        }
        
        SetText(children - 1);


    }

    public void Slide(int direction)
    {
        sliding = true;
        dir = direction;
        Invoke("SetSlideToFalse", 0.25f);
    }

    void SetSlideToFalse()
    {
        sliding = false;
    }
}
