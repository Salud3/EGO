using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public TMP_Text textTime;
    public float time = 0;
    public GameObject panelFinish;
    public TextMeshProUGUI totalPointsText;

    public bool start;
    public bool finish;


    [Header("Others")]
    public Sprite sprite;
    public GameObject objectOff;
    public Image charging;

    private void Start()

    {
        Instance = this;
        if (panelFinish != null)
        {
            panelFinish.SetActive(false);
            StartCoroutine(numerable());
        }
    }

    IEnumerator numerable()
    {
        yield return new WaitForSeconds(2.8f);
        start = true;
    }

    void Update()
    {
        if (start)
        {
            if (time > 0.01f)
            {

            time -= Time.deltaTime;
            textTime.text = "" + time.ToString("##.#");
            }else
            {
                time = 0;
               //Time.timeScale = 0f;
                if (!finish)
                {
                ActivatePanel();
                    
                }

            }
        }
    }
    void ActivatePanel()
    {
            charging.sprite = sprite;
            Animator animator = charging.GetComponent<Animator>();
        Debug.Log("A");
            GameManager.Instance.SceneLoad(SceneManager.GetActiveScene().buildIndex + 1);
            animator.SetTrigger("In");
        finish = true;
        
        /*if (panelFinish != null)
        {*/
            //totalPointsText.text = ("Your final score: ") + GameManager.Instance.TotalPoints.ToString();

        //}
    }
}
