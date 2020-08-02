using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;

    AudioSource [] s;

    public AudioClip click;
    public AudioClip hit;
    public AudioClip coin;

    void Awake()
    {
        soundManager = this;
        Vibration.Vibrate(0);
    }

    public void Click()
    {
        s = GetComponents<AudioSource>();
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i].clip == click)
                s[i].Play();
        }
    }

    public void Hit()
    {
        s = GetComponents<AudioSource>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].clip == hit)
            {
                s[i].Play();
                Vibration.Vibrate(30);
            }
                
        }
    }

    public void Coin()
    {
        s = GetComponents<AudioSource>();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].clip == coin)
                s[i].Play();
        }
    }
}
