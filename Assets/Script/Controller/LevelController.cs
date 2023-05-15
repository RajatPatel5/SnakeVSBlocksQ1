using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;


    public Button start;



    public Text scoreText;

    public Text GameoverScoreText;

    public float gameSpeed= 4;

    public int BoxAmount = 6;

    public float damageTime = 0.1f;

    public float blockLineDistance = 13;

    public ObjectPool objectPool;

    public Vector2 xLimit;

    public float multiplier = 1;

    private Transform player;

    public float cicleTime=10;

    private int points;

    public Color R, G, B;
    public GameObject MainScreen;
   
    public GameObject boxs1;
    public GameObject boxs2;

   // public Sprite DeathPlayer;

    public bool gameOver = true;

   

    private void Awake()
    {
        gameSpeed = 0;
       // Time.timeScale = 0f;
        start.onClick.AddListener(StartBtn);
        boxs1.SetActive(false);
        boxs2.SetActive(false);
    }

  
    void Start()
    {
    
        //  player.gameObject.GetComponent<SpriteRenderer>().sprite = DeathPlayer;
        boxs1.SetActive(true);
        boxs2.SetActive(true);

        instance = this;

        player = FindObjectOfType<Player>().transform;

        SpawnPicups();

        InvokeRepeating("Difficulty", cicleTime, cicleTime);

      
    }
  



    public void StartBtn()
    {
        
        ScreenManager.inst.SwitchScreen(ScreenType.Screen2);
        gameSpeed = 4;
        
    }

    public void RetryBtn()
    {
      //  Application.LoadLevel(Application.LoadLevel);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

      
       
        ScreenManager.inst.SwitchScreen(ScreenType.Screen2);
        Time.timeScale = 1f;
      
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        GameoverScoreText.text = scoreText.text;
        gameOver = true;
        Time.timeScale = 0f;
        ScreenManager.inst.SwitchScreen(ScreenType.Screen3);
    }

    public void RestartScene()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Score(int amount)
    {
        points += amount;

        scoreText.text = points.ToString();
    }


    void Difficulty()
    {

        BoxAmount += 2;
        multiplier *= 1.1f;
    }

    void SpawnPicups()
    {
        objectPool.GetObject().transform.position = new Vector2(Random.Range(xLimit.x, xLimit.y), player.position.y + 10);

        Invoke("SpawnPicups", Random.Range(1f, 3f));
    }
}
