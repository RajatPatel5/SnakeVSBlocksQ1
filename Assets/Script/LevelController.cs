using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

 
    public GameObject gameOverPanel;

    public Text scoreText;

    public float gameSpeed= 2;

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


    public GameObject boxs1;
    public GameObject boxs2;

    public bool gameOver = true;

    private void Awake()
    {
        boxs1.SetActive(false);
        boxs2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
      
        boxs1.SetActive(true);
        boxs2.SetActive(true);

        instance = this;

        player = FindObjectOfType<Player>().transform;

        SpawnPicups();

        InvokeRepeating("Difficulty", cicleTime, cicleTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  

    public void GameOver()
    {
        gameOver = true;
        gameSpeed = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        objectPool.GetObject().transform.position = new Vector2(Random.Range(xLimit.x, xLimit.y), player.position.y + 15);

        Invoke("SpawnPicups", Random.Range(1f, 3f));
    }
}
