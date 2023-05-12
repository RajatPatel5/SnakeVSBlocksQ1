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
    // Start is called before the first frame update
    void Start()
    {
       // lastYpos = transform.position.y;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{
            // Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.);
         

       // }
        // transform.position = new Vector2(Mathf.Clamp(transform.position.x, -5, 5), transform.position.y);

    }



    private void FixedUpdate()
    {

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float PosX = worldPoint.x;

        mouseDistance = Mathf.Clamp(PosX - transform.position.x, -1, 1);

        if (LevelController.instance.gameOver)
            return;

        if (!sliding)
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
            Destroy(transform.GetChild(children - 1).gameObject);
            LevelController.instance.Score(1);
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
