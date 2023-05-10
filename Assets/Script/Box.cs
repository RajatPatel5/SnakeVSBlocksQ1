using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public Text amountText;

    private int amount;

    private Player player;

    private float nextTime;

    private Color initialColor;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // SetAmount();
       gameObject.SetActive(false);
     }

    // Update is called once per frame
    void Update()
    {
        if(player != null && nextTime <Time.time)
        {
            PlayerDamage();
        }
    }

    public void SetAmount()
    {
       gameObject.SetActive(true);
        amount = Random.Range(0,LevelController.instance.BoxAmount);
        if(amount <= 0)
        {
            gameObject.SetActive(false);
        }
        SetAmountText();
        SetColor();
    }

    public void SetAmountText()
    {
        amountText.text = amount.ToString();

    }
    public void SetColor()

    {
        int playerLives = FindObjectOfType<Player>().transform.childCount;
        Color newColor;

        if(amount > playerLives)
        {
            newColor = LevelController.instance.R;
        }
        else if(amount > playerLives /2)
        {
            newColor = LevelController.instance.B;


        }
        else
        {
            newColor = LevelController.instance.G;
        }
        spriteRenderer.color = newColor;
        initialColor = newColor;
    }


    void PlayerDamage()
    {
        nextTime = Time.time + LevelController.instance.damageTime;
        player.TackDamage();
        amount--;
        SetAmountText();
        if(amount <= 0)
        {
            gameObject.SetActive(false);
            player = null;
        }
        else
        {
            StopAllCoroutines();
            StartCoroutine(DamageColor());
        }
    }
    IEnumerator DamageColor()
    {
        float timer = 0;
        float t = 0;

        spriteRenderer.color = initialColor;

        while(timer < LevelController.instance.damageTime)
        {
            spriteRenderer.color = Color.Lerp(initialColor, Color.white, t);
               timer += Time.deltaTime;
            t += Time.deltaTime / LevelController.instance.damageTime;
            yield return null;

        }

        spriteRenderer.color = initialColor;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Player otherPlayer = other.gameObject.GetComponent<Player>();

        if(otherPlayer != null)
        {
            player = otherPlayer;
        }
        
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        Player otherPlayer = other.gameObject.GetComponent<Player>();

        if (otherPlayer != null)
        {
            player = null;
        }
    }

}
