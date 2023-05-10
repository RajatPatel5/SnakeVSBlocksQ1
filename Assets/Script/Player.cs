using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float mouseDistance;

    private Rigidbody2D rb;

 
    public Text childText;

    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
       // lastYpos = transform.position.y;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float PosX = worldPoint.x;

        mouseDistance = Mathf.Clamp(PosX - transform.position.x, -1,1);

      //  transform.position = new Vector2(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y);

    }



    private void FixedUpdate()
    {
        if (LevelController.instance.gameOver)
            return;

        rb.velocity = new Vector2(mouseDistance * speed, LevelController.instance.gameSpeed * LevelController.instance.multiplier);
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
            Destroy(transform.GetChild(children - 1).gameObject);
            LevelController.instance.Score(1);
        }
        SetText(children - 1);

    }
}
