using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : BaseScreen
{
    bool setting = true;
    bool audiomute = true;
    public Image mute;
    public GameObject AudioBtn;

 

    private void Start()
    {
        AudioBtn.SetActive(false);
    }

    public void SettingsBtn()
    {  

        if (setting == true)
        {
           
            AudioBtn.SetActive(true);
            setting = false;
        }
        else
        {
           
            AudioBtn.SetActive(false);
            setting = true;
        }
    }
    public void Audio()
    {
        if (audiomute == true)
        {
            mute.enabled = false;
            AudioManager.inst.audioSource.mute = true;
            audiomute = false;
        }
        else
        {
            mute.enabled = true;
            AudioManager.inst.audioSource.mute = false;
            audiomute = true;
        }
    }
  public  void ChangePlayer()
    {
        
        ScreenManager.inst.SwitchScreen(ScreenType.Screen4);
      
    }

    public void StartButton()
    {
        ScreenManager.inst.SwitchScreen(ScreenType.Score);
        AudioManager.inst.PlayAudioBG(AudioManager.AudioName.Audio2GameBG);
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        LevelController.instance.StartBtn();
    }
    public void Exit()
    {
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        Application.Quit();
    }
  public  void BackToMain()
    {
      
        ScreenManager.inst.SwitchScreen(ScreenType.MainScreen);

       
    }


}
