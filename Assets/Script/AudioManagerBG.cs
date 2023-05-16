using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerBG : MonoBehaviour
{
    public static AudioManagerBG inst;

    [SerializeField]public AudioSource audioSource;


    public Audio[] clips;


    void Start()
    {
        inst = this;
    }

    public void PlayAudio(AudioName name)
    {
       
        foreach (var item in clips)
        {
            if (item.name == name)
            {

                audioSource.clip = item.clip;
                audioSource.Play();


                break;
            }
        }
    }

    [System.Serializable]
    public class Audio
    {
        public AudioName name;
        public AudioClip clip;


    }


    public enum AudioName
    {
        Audio1MainBG,
        Audio2GameBG,
        
    }

}
