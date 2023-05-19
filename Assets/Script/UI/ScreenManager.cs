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
        inst = this;
        CurrentScreen.canvas.enabled = true;
        AudioManagerBG.inst.PlayAudio(AudioManagerBG.AudioName.Audio1MainBG);
        AudioManagerBG.inst.audioSource.Play();

      

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
    }

}
