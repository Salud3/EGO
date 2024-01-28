using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GMaster1 : MonoBehaviour
{
    public static GMaster1 Instance;
    public PlayerMovement player;
    public GameObject finish;

    [SerializeField] float damageSpeed = 6;
    [SerializeField] float speed = 1;
    public float maxSpeed = 13; public float Speed { get { return speed; } }
    public bool startG;
    public bool finished;

    [Header("Minutero")]
    [SerializeField] float timer;
    [SerializeField] TextMeshProUGUI Minutero;   
    public float Tim{ get { return timer; } }
    int minutos, segundos, cent;


    [Header("Minutero")]
    [SerializeField] float distance;
    public float Dist { get { return distance; } }
    [SerializeField] TextMeshProUGUI Distance;
    float xPlayer;
    public float xRun { get { return xPlayer; } }


    [Header("Others")]
    public Sprite sprite;
    public GameObject objectOff;
    public Image charging;
    public void OffObject()
    {
        objectOff.SetActive(false);
    }
    public void OnObject()
    {
        objectOff.SetActive(true);
    }
    public void ChangeCharging()
    {
        charging.sprite = sprite;
    }


    private void Awake()
    {
        Instance = this;
        timer = 0;
    }
    public void ChangeUpSpeed()
    {
        float a = Time.fixedDeltaTime * 0.08f;
        speed += a;

    }

    public void ChangeDownSpeed()
    {
        if (speed <= damageSpeed*1.5)
        {
            Debug.Log("Choque en velocidad minima");
        }
        else
        {
            speed -= damageSpeed;
        }
    }
    
    void CalcTime()
    {
        if (!finished)
        {

        timer += Time.deltaTime;
        minutos = (int)(timer / 60);
        segundos = (int)(timer - minutos * 60f);
        cent = (int)((timer - (int)timer) * 100f);

        Minutero.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, cent);
        }
        else
        {

        }
    }
    
    void Update()
    {
        if (!startG&&Input.GetKeyDown(KeyCode.Space))
        {
            startG = true;
            OffObject();

        }
        if (startG)
        {
            if (!finished)
            {
            CalcTime();
            ChangeUpSpeed();
            }
            else
            {
                Debug.Log("Finished");
                if (minutos > 1)
                {
                    GameManager.Instance.ScorePoints(100);
                }
                else 
                {
                    GameManager.Instance.ScorePoints(350);
                }
                if (!Charge)
                {
                    End();

                }
                speed = 0.2f;
            }
        }
        
    }
    bool Charge;
    void End()
    {
        Charge = true;
        charging.sprite = sprite;
        Animator animator = charging.GetComponent<Animator>();
        animator.SetTrigger("In");
        StartCoroutine(StartChangeScene());
    }
    IEnumerator StartChangeScene()
    {
        yield return new WaitForSeconds(3.2f);
        GameManager.Instance.SceneLoad(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(player.gameObject.transform.position, finish.transform.position);
        Distance.text = "Distance to Goal: " + distance.ToString("#.#") + " Mts";

        xPlayer = -(player.transform.position.x - finish.transform.position.x);

        Debug.Log(xPlayer.ToString("#.#"));
    }

}
