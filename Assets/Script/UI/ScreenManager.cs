using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{

    public BaseScreen[] screen;
    public BaseScreen CurrentScreen;
    public static ScreenManager inst;


    void Start()
    {
        GameStateManager.OnStateChange(GameStates.HomeScreen);
        inst = this;
        CurrentScreen.canvas.enabled = true;
        AudioManager.inst.PlayAudioBG(AudioManager.AudioName.Audio1MainBG);
        AudioManager.inst.audioSource.Play();

      

    }

    public void SwitchScreen(ScreenType screenType)
    {
        CurrentScreen.canvas.enabled = false;

        foreach(BaseScreen baseScreen in screen)
        {
            if(baseScreen.screenType == screenType)
            {
                baseScreen.canvas.enabled = true;
                CurrentScreen = baseScreen;
                break;
            }
        }

        switch (screenType)
        {
            case ScreenType.MainScreen:
                GameStateManager.OnStateChange(GameStates.HomeScreen);
                break;
            case ScreenType.Score:
                GameStateManager.OnStateChange(GameStates.GamePlay);
                break;
            case ScreenType.GameOver:
                GameStateManager.OnStateChange(GameStates.GameOver);
                break;
        }
    }

}
