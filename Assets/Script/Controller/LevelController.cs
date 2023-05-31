using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LevelController : MonoBehaviour
{
    public static LevelController instance;



    [Header("-------------UI------------")]


    public Text coin;
    public Text coin1;
    public Text coin2;
    public Text StartText;
    public Text scoreText;
    public Text highScore;
    public Text GameoverScoreText;
    public Color R, G, B;
   
    public SpriteRenderer sprite;
    [Header("--------GameObject--------")]
   
    public GameObject followplayer;
    public GameObject BackGround;
    public GameObject boxs1;
    public GameObject boxs2;
    public GameObject boxs3;
    public GameObject AudioBtn;
    public ObjectPool objectPool;
    public ObjectPoolCoin objectPool2;
    public Vector2 xLimit;
    private Transform player;

    [Header("-------------Var------------")]
    public float gameSpeed = 4;
    public int BoxAmount = 6;
    public float damageTime = 0.1f;
    public float blockLineDistance = 13;
    public float multiplier = 1;
    public float cicleTime = 10;
    public int points;
   
    public bool gameOver = true;
    [Header("------------Array-------------")]
    public Sprite[] bgsprite;
    public GameObject[] SFX;

    [Header("-----------Particle-----------")]
    public ParticleSystem Show;

    private void Awake()
    {
        BackGround.SetActive(false);
        Show.Stop();

       // gameSpeed = 0;
      
        boxs1.SetActive(false);
        boxs2.SetActive(false);
        boxs3.SetActive(false);

    }

    void Start()
    {
       
        AudioBtn.SetActive(false);
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        boxs1.SetActive(true);
        boxs2.SetActive(true);
        boxs3.SetActive(true);

        instance = this;

        player = FindObjectOfType<Player>().transform;
        InvokeRepeating("Difficulty", cicleTime, cicleTime);
        SpawnPicups();
        SpawnCoin();
    }
   


   


    public void StartBtn()
    {
        BackGround.SetActive(true);
        Show.Play();
       // GameManager.instance.UpdateGameState(GameState.GamePlayScreen);
        followplayer.GetComponent<FollowPlayer>().AddTail();
        followplayer.GetComponent<FollowPlayer>().AddTail();
        followplayer.GetComponent<FollowPlayer>().AddTail();
        followplayer.GetComponent<FollowPlayer>().AddTail();

        sprite.sprite = bgsprite[Random.Range(0, bgsprite.Length - 1)];


        scoreText.text = "0";



        gameSpeed = 4;
        BoxAmount = 6;
        multiplier = 1;

        for (int i = 0; i < SFX.Length; i++)
        {
            SFX[i].SetActive(false);
        }

        int s = Random.Range(0, SFX.Length);
        SFX[s].SetActive(true);

        gameOver = false;


    }

    public void RetryBtn()
    {
        Show.Play();
       
       

        sprite.sprite = bgsprite[Random.Range(0, bgsprite.Length - 1)];
        for (int l = 0; l < SFX.Length; l++)
        {
            SFX[l].SetActive(false);
        }

        int s = Random.Range(0, SFX.Length);
        SFX[s].SetActive(true);

        boxs1.transform.position = new Vector2(0, 16);
        boxs2.transform.position = new Vector2(0, 35);
        boxs3.transform.position = new Vector2(0, 54);

        boxs1.GetComponent<Boxs>().Start();
        boxs2.GetComponent<Boxs>().Start();
        boxs3.GetComponent<Boxs>().Start();

        AudioManager.inst.audioSource.Play();
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        ScreenManager.inst.SwitchScreen(ScreenType.Score);

        scoreText.text = "0";
        int i = int.Parse(GameoverScoreText.text);
        Score(-i);

        gameOver = false;
        BoxAmount = 6;
        gameSpeed = 4;
        multiplier = 1;
        player.transform.position = new Vector3(-0.0900000036f, -1.82000005f, 0);
        followplayer.GetComponent<FollowPlayer>().AddTail();
        followplayer.GetComponent<FollowPlayer>().AddTail();
        followplayer.GetComponent<FollowPlayer>().AddTail();
        followplayer.GetComponent<FollowPlayer>().AddTail();
       


    }
   



    public void GameOver()
    {
       
        Show.Stop();
        int i = int.Parse(scoreText.text);
        if (i > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", i);
            highScore.text = i.ToString();
        }

        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio3GameOver);


        StartCoroutine("WaitFiveSeconds");
        GameoverScoreText.text = scoreText.text;
        
        Debug.Log(coin1.text);
        gameOver = true;
        gameSpeed = 0;
        ScreenManager.inst.SwitchScreen(ScreenType.GameOver);
        coin1.text = coin.text;
        coin2.text = coin1.text;


    }

    IEnumerator WaitFiveSeconds()
    {
       
        // Pause the game
        //Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        AudioManager.inst.audioSource.Stop();
       
    }

    public void RestartScene()
    {
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        AudioManager.inst.PlayAudioBG(AudioManager.AudioName.Audio1MainBG);

        boxs1.transform.position = new Vector2(0, 16);
        boxs2.transform.position = new Vector2(0, 35);
        player.transform.position = new Vector2(0, 0);
        boxs3.transform.position = new Vector2(0, 54);

        boxs1.GetComponent<Boxs>().Start();
        boxs2.GetComponent<Boxs>().Start();
        boxs3.GetComponent<Boxs>().Start();

        ScreenManager.inst.SwitchScreen(ScreenType.MainScreen);
       // GameManager.instance.UpdateGameState(GameState.MainScreen);

        int i = int.Parse(GameoverScoreText.text);
        Score(-i);

        for (int l = 0; l < SFX.Length; l++)
        {
            SFX[l].SetActive(false);
        }
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
        if (!gameOver)
            objectPool.GetObject().transform.position = new Vector2(Random.Range(xLimit.x, xLimit.y), player.position.y + 15);
        Invoke("SpawnPicups", Random.Range(0f, 3f));
    }
    void SpawnCoin()
    {
        if (!gameOver)
            objectPool2.GetObjectCoin().transform.position = new Vector2(Random.Range(xLimit.x, xLimit.y), player.position.y + 20);
        Invoke("SpawnCoin", Random.Range(0f, 3f));
    }
}
