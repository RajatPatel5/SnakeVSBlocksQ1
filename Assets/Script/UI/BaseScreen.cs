using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseScreen : MonoBehaviour
{

    public ScreenType screenType;

    public Canvas canvas;

    public void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
}


public enum ScreenType
{
    MainScreen,
    Score,
    GameOver,
    Screen4,
    Pause
}