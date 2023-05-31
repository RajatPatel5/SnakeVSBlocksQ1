using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public Action action;

    private float touchDistance;

    private Rigidbody2D rb;

    private bool sliding;

    private int dir;

    public Text childText;
    public Text coin;
    

    public GameObject prefab;
    public Transform Point;

    public float speed = 2;


    public GameObject Prefab;


    private float deltaX;

    private int points;

    private void OnEnable()
    {
        GameStateManager.OnStateChange += ChangeState;
    }
    private void OnDisable()
    {
        GameStateManager.OnStateChange -= ChangeState;
    }

    private void ChangeState(GameStates state)
    {
        switch (state)
        {
            case GameStates.HomeScreen:
               
                action -= MovePlayer;
                break;
            case GameStates.GameOver:
                
                action -= MovePlayer;
                break;
            case GameStates.GamePlay:
               
                action += MovePlayer;
                break;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }


    private void FixedUpdate()
    {
       
        action?.Invoke();
    }

    private void MovePlayer()
    {
      

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {

                case TouchPhase.Moved:
                    deltaX = touchPos.x;
                    break;
            }
        }

        touchDistance = deltaX - transform.position.x;
        
      

        if (!sliding)
        {
            rb.velocity = new Vector2(touchDistance * speed, LevelController.instance.gameSpeed * LevelController.instance.multiplier);
        }
        else
        {
            rb.velocity = new Vector2(dir * 2.5f, LevelController.instance.gameSpeed * LevelController.instance.multiplier);
        }


    }


    //public void DeleteObject()
    //{
    //    int j = transform.childCount;

    //    for (int i = 3; i < j; i++)
    //    {

    //        FollowPlayer followPlayer = GetComponent<FollowPlayer>();
    //        followPlayer.Delete();
    //        Destroy(transform.GetChild(j - 1).gameObject);
    //    }

    //}


    public void SetTextCoin(int coins)
    {

      
            points += coins;
            coin.text = points.ToString();

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
        if (children < 2)
        {
            LevelController.instance.GameOver();
            rb.velocity = Vector2.zero;
          
        }
        else
        {

          
            FollowPlayer followPlayer = GetComponent<FollowPlayer>();
            followPlayer.Delete();
          
            Destroy(transform.GetChild(children - 1).gameObject);
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
