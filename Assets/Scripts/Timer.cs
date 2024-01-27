using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text textTime;
    public float time = 0;
    public GameObject panelFinish;

    private void Start()
    {
        if (panelFinish != null)
        {
            panelFinish.SetActive(false);
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        textTime.text = "" + time.ToString("f2");

        if (time < 0.000f)
        {
            Time.timeScale = 0f;
            ActivatePanel();
        }
    }
    void ActivatePanel()
    {
        if (panelFinish != null)
        {
            panelFinish.SetActive(true);
        }
    }
}
