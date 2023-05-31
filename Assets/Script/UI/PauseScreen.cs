using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : BaseScreen
{
    public GameObject g;


    public void PauseBtn()
    {
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
        ScreenManager.inst.SwitchScreen(ScreenType.Pause);
        Time.timeScale = 0f;
    }
    public void ResumeBtn()
    {
        Time.timeScale = 1f;
        ScreenManager.inst.SwitchScreen(ScreenType.Score);
        AudioManager.inst.PlayAudio(AudioManager.AudioName.Audio4UIButton);
    }
    public void HomeBtn()
    {
       
        for (var i = g.transform.childCount - 1; i >= 1; i--)
        {

            FollowPlayer follow = g.GetComponent<FollowPlayer>();
            follow.Delete();
            Object.Destroy(g.transform.GetChild(i).gameObject);
        }
        Time.timeScale = 1f;
        LevelController.instance.RestartScene();
        LevelController.instance.points=0;
    }



}
