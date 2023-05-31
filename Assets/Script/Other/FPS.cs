using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System;

public class FPS : MonoBehaviour
{
    public int avgFrameRate;
    public Text display_Text;

    public void Update()
    {

      
         Application.targetFrameRate = 30;
        float current = 0;
        current = Time.frameCount / Time.time;
        avgFrameRate = (int)current;
        display_Text.text = avgFrameRate.ToString() + " FPS";
    }
}




//public class UIManager : MonoBehaviour
//{
//    public static UIManager inst;
//    public List<screen> screenList;
//    public screen currentScreen;

//    private void Awake()
//    {
//        inst = this;
//        currentScreen = screenList[0];
//    }

//    public void ShowNextScreen(ScreenEnum ScreenType)
//    {
//        if (currentScreen != null)
//            currentScreen.HideScreen();

//        screenList[(int)ScreenType].ShowScreen();
//        currentScreen = screenList[(int)ScreenType];

//        if (ScreenType == ScreenEnum.GamePlay)
//        {
//            Spawner.inst.OnAction += Spawner.inst.BallSpawn;
//        }

//    }

//}



//public class Splash : screen
//{
//    public Image image;
//    public static Splash inst;

//    private void Start()
//    {

//        inst = this;
//        image = GetComponent<Image>();

//        UIManager.inst.ShowNextScreen(ScreenEnum.Splash);
//        StartCoroutine(EnableMainMenu());

//    }


//    IEnumerator EnableMainMenu()
//    {
//        yield return new WaitForSeconds(2);
//        UIManager.inst.ShowNextScreen(ScreenEnum.MainMenu);
//    }

//}
//public class Lerpimg : MonoBehaviour
//{
//    public Image image;
//    public float second = 2f;
//    public float target = 0f;
//    private float currentAlpha;

//    private void Start()
//    {
//        currentAlpha = image.color.a;

//    }
//    private void Update()
//    {
//        StartCoroutine(Fade());
//    }

//    IEnumerator Fade()
//    {
//        //start to end time of event
//        float elapsedTime = Time.time;
//        //Debug.Log("elapsed" + elapsedTime);
//        //Debug.Log("Time" + Time.time);
//        float newAlpha = Mathf.Lerp(currentAlpha, target, elapsedTime / second);

//        Color newColor = image.color;
//        newColor.a = newAlpha;
//        image.color = newColor;
//        yield return image.color;
//    }

//}