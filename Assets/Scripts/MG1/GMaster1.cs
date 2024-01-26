using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        timer += Time.deltaTime;
        minutos = (int)(timer / 60);
        segundos = (int)(timer - minutos * 60f);
        cent = (int)((timer - (int)timer) * 100f);

        Minutero.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, cent);
    }
    
    void Update()
    {
        if (!startG&&Input.GetKeyDown(KeyCode.Space))
        {
            startG = true;


        }
        if (startG)
        {
            CalcTime();
            ChangeUpSpeed();
        }
    }


    private void FixedUpdate()
    {
        distance = Vector2.Distance(player.gameObject.transform.position, finish.transform.position);
    }

}
