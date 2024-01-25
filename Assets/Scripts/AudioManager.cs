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

    public float defaultVolume = .5f;
    public float SavedMusicVolume = .5f;
    public float SavedSFXVolume = .5f;


    public bool init;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
            DontDestroyOnLoad(gameObject);

        SavedSFXVolume = PlayerPrefs.GetFloat("SFXVolume",defaultVolume);
        SavedMusicVolume = PlayerPrefs.GetFloat("MusicVolume",defaultVolume);
    }
    public void SetVolumePref()
    {
        PlayerPrefs.SetFloat("SFXVolume", SavedSFXVolume);
        PlayerPrefs.SetFloat("MusicVolume", SavedMusicVolume);
    }

   private void Start()
    {
        ChargeMusicLevel();
    }

    public void ChargeMusicLevel()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                PlayMusic("MainTheme");
                init = true;
                break;
            case 1:
                PlayMusic("Etapa1");
                init = true;
                break;
            case 2:
                PlayMusic("Etapa2");
                init = true;
                break;
            case 3:
                PlayMusic("Etapa3");
                init = true;
                break;
            case 4:
                PlayMusic("Final");
                init = true;
                break;
            case 5:
                PlayMusic("BadEnd");
                init = true;
                break;
            case 6:
                PlayMusic("GoodEnd");
                init = true;
                break;
            default:
                PlayMusic("MainTheme");
                init = true;
                break;
        }
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
        SetVolumePref();
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume*volume;
        SavedSFXVolume = volume;
        SetVolumePref();

    }
}
