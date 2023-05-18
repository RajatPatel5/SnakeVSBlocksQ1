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
    public GameObject boxs3;

    public GameObject AudioBtn;
   
    public Image mute;
   

    bool setting = true;

    bool audiomute = true;


    public bool gameOver = true;

    public Sprite[] bgsprite;

    public GameObject[] SFX;
    public SpriteRenderer sprite;

    //public GameObject Gameoverprefab;
    //public GameObject gameoverpoint;

    private void Awake()
    {
       

        gameSpeed = 0;
       // Time.timeScale = 0f;
        start.onClick.AddListener(StartBtn);
        ChangeColor.onClick.AddListener(ChangePlayer);
        Back.onClick.AddListener(BackToMain);
        boxs1.SetActive(false);
        boxs2.SetActive(false);
        boxs3.SetActive(false);

    }

    
  
    void Start()
    {
       
        AudioBtn.SetActive(false);
      
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
       

        //  player.gameObject.GetComponent<SpriteRenderer>().sprite = DeathPlayer;
        boxs1.SetActive(true);
        boxs2.SetActive(true);
        boxs3.SetActive(true);

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
        sprite.sprite = bgsprite[Random.Range(0, bgsprite.Length - 1)];
        if (audiomute == true)
        {
            AudioManagerBG.inst.PlayAudio(AudioManagerBG.AudioName.Audio2GameBG);
        }
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        ScreenManager.inst.SwitchScreen(ScreenType.Screen2);
        SpawnPicups();
        gameSpeed = 4;
        // scoreText.text = ("0");
        // GameoverScoreText.text = ("0");
        // Score(0);
        BoxAmount = 6;

        multiplier = 1;

        for(int i = 0;i<SFX.Length;i++)
        {
            SFX[i].SetActive(false);
        }

        int s = Random.Range(0, SFX.Length);
        SFX[s].SetActive(true);

        gameOver = false;

       




    }

    public void RetryBtn()
    {
        sprite.sprite = bgsprite[Random.Range(0, bgsprite.Length - 1)];
        for (int l = 0; l < SFX.Length; l++)
        {
            SFX[l].SetActive(false);
        }

        int s = Random.Range(0, SFX.Length);
        SFX[s].SetActive(true);
      

        //  Application.LoadLevel(Application.LoadLevel);
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        boxs1.transform.position = new Vector2(0,16);
        boxs2.transform.position = new Vector2(0,30);
        boxs3.transform.position = new Vector2(0, 44);
        player.transform.position = new Vector2(0, 0);
        ScreenManager.inst.SwitchScreen(ScreenType.Screen2);
        AudioManagerBG.inst.audioSource.Play();

        scoreText.text = "0";
        int i = int.Parse(GameoverScoreText.text);
        Score(-i);
        gameOver = false;

      
        //Time.timeScale = 1f;
        // Score(0);
        BoxAmount = 6;
        gameSpeed = 4;
        multiplier = 1;
        


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
        // Time.timeScale = 0f;
       // gameSpeed = 0;

        ScreenManager.inst.SwitchScreen(ScreenType.Screen3);
      //  Instantiate(Gameoverprefab,gameoverpoint.transform.position, Quaternion.identity);
    }

    public void RestartScene()
    {
        AudioManagerBG.inst.audioSource.Play();
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        AudioManagerBG.inst.PlayAudio(AudioManagerBG.AudioName.Audio1MainBG);
       // AudioManagerBG.inst.audioSource.Stop();
         mute.enabled = true;
        audiomute = true;

        boxs1.transform.position = new Vector2(0, 16);
        boxs2.transform.position = new Vector2(0, 30);
        player.transform.position = new Vector2(0, 0);
        boxs3.transform.position = new Vector2(0, 44);
        ScreenManager.inst.SwitchScreen(ScreenType.Screen1);

        
        int i = int.Parse(GameoverScoreText.text);
        Score(-i);

        for (int l = 0; l < SFX.Length; l++)
        {
            SFX[l].SetActive(false);
        }

        //Time.timeScale = 1f;
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
        if (gameOver==false)
            objectPool.GetObject().transform.position = new Vector2(Random.Range(xLimit.x, xLimit.y), player.position.y + 15);

            Invoke("SpawnPicups", 5);//Random.Range(0f, 5f));
      
    }
}
