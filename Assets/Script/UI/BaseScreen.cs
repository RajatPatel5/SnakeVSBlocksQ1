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
    }



}


public enum ScreenType
{
    Screen1,
    Screen2,
    Screen3,
}