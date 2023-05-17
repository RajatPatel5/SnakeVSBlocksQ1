using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;


    public Button start;

    public Button ChangeColor;

    public Button Back;
   

    public Text scoreText;
    public Text highScore;

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

    public GameObject AudioBtn;
    public Image mute;

    bool setting = true;

    bool audiomute = true;

    public bool gameOver = true;

   

    private void Awake()
    {
       

        gameSpeed = 0;
       // Time.timeScale = 0f;
        start.onClick.AddListener(StartBtn);
        ChangeColor.onClick.AddListener(ChangePlayer);
        Back.onClick.AddListener(BackToMain);
        boxs1.SetActive(false);
        boxs2.SetActive(false);
     

    }

    
  
    void Start()
    {
        AudioBtn.SetActive(false);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
       

        //  player.gameObject.GetComponent<SpriteRenderer>().sprite = DeathPlayer;
        boxs1.SetActive(true);
        boxs2.SetActive(true);

        instance = this;

        player = FindObjectOfType<Player>().transform;

      

        InvokeRepeating("Difficulty", cicleTime, cicleTime);
       



    }

    void ChangePlayer()
    {
        ScreenManager.inst.SwitchScreen(ScreenType.Screen4);
    }

    void BackToMain()
    {
        ScreenManager.inst.SwitchScreen(ScreenType.Screen1);
    }

    public void SettingsBtn()
    {
        if(setting == true)
        {
            AudioBtn.SetActive(true);
            setting = false;
        }
        else
        {
            AudioBtn.SetActive(false);
            setting = true;
        }
    }

    public void Audio()
    {
        if(audiomute == true)
        {
            mute.enabled = false;
            AudioManagerBG.inst.audioSource.Stop();
          
            audiomute = false;

        }
        else
        {
            mute.enabled = true;
            AudioManagerBG.inst.audioSource.Play();
          
            audiomute = true;
        }
    }

    public void StartBtn()
    {
        if (audiomute == true)
        {
            AudioManagerBG.inst.PlayAudio(AudioManagerBG.AudioName.Audio2GameBG);
        }
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        ScreenManager.inst.SwitchScreen(ScreenType.Screen2);
        SpawnPicups();
        gameSpeed = 4;
        
    }

    public void RetryBtn()
    {
        //  Application.LoadLevel(Application.LoadLevel);
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

      
       
        ScreenManager.inst.SwitchScreen(ScreenType.Screen2);
        Time.timeScale = 1f;
      
        
    }

    public void Exit()
    {
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        Application.Quit();
    }

    public void GameOver()
    {
      int i =  int.Parse(scoreText.text);
        if(i> PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", i);
            highScore.text = i.ToString();
        }

        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio3GameOver);
        AudioManagerBG.inst.audioSource.Stop();
        GameoverScoreText.text = scoreText.text;
        gameOver = true;
        Time.timeScale = 0f;
        ScreenManager.inst.SwitchScreen(ScreenType.Screen3);
    }

    public void RestartScene()
    {
        AudioManagerBG.inst.audioSource.Play();
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
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
