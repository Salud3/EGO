using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds,sfxSounds;
    public AudioSource musicSource, sfxSource;

    public float SavedMusicVolume = .5f;
    public float SavedSFXVolume = .5f;

    public bool init;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

   private void Start()
    {
        ChargeMusicLevel();
    }

    public void ChargeMusicLevel()
    {
        musicSource.Stop();
        Debug.Log("change music" + SceneManager.GetActiveScene().buildIndex);
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                PlayMusic("MainTheme");
                init = true;
                break;
            case 1:
                PlayMusic("Dentadura");
                init = true;
                break;
            case 2:
                PlayMusic("Alberca");
                init = true;
                break;
            case 3:
                PlayMusic("1000Mts");
                init = true;
                break;
            case 4:
                PlayMusic("Atrapar");//Credits
                init = true;
                break;
            case 5:
                PlayMusic("MainTheme");
                init = true;
                break;
            default:
                PlayMusic("MainTheme");
                init = true;
                break;
        }
        MusicVolume(SavedMusicVolume);
        SFXVolume(SavedSFXVolume);
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    } 

    public void PlaySounds(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume*volume;
        SavedMusicVolume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume*volume;
        SavedSFXVolume = volume;
    }

}
