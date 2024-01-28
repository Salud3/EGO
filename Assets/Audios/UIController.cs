using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxslider;

    public bool onOthers;
    
    private void Awake()
    {
        _musicSlider = GameObject.Find("/Canvas/MenuOptions/SliderMusic").GetComponent<Slider>();
        _sfxslider = GameObject.Find("/Canvas/MenuOptions/SliderSFX").GetComponent<Slider>();
        _sfxslider.value = .5f;
        _musicSlider.value = .5f;

    }

    private void Start()
    {

        GameObject a = _musicSlider.gameObject.transform.parent.gameObject;
        a.SetActive(false);

    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Reanude()
    {
        Time.timeScale = 1.0f;
    }
    public void Play()
    {
        GameManager.Instance.SceneLoad(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxslider.value);
    }
    public void Exit()
    {
        Application.Quit();
    }

    


}
