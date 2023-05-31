using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{

    public Text text;
    float startRadius = 0;
    float endRadius = 255;
    float duration = 1f;
    public float timer = 60;


    // Start is called before the first frame update
    void Start()
    {
        Color radius = text.color;
      StartCoroutine(ChangeRadius(startRadius, endRadius, duration));
       // timer = 60*60;
    }

    // Update is called once per frame
    void Update()
    {
       // timer--;
       //// timer /= 60;
       // text.text = (timer/60).ToString("0");
       // Debug.Log(timer);
    }
    IEnumerator ChangeRadius(float startRadius, float endRadius, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            float A = Mathf.Lerp(startRadius, endRadius, duration);
            text.color =new Color(255,255,255,A);
            elapsed += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(ChangeRadius(endRadius, startRadius, 1));
    }
}
