using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMaster1 : MonoBehaviour
{
    public static GMaster1 Instance;
    public PlayerMovement player;

    public float maxSpeed;
    [SerializeField] float timer;
    public bool startG;
    public bool finished;
    

    private void Awake()
    {
        Instance = this;
        timer = 0;
    }
    public void ChangeUpSpeed()
    {
        float a = Time.fixedDeltaTime * 0.08f;
        if (GameMovement.Instance.cameraSpeed < maxSpeed)
        {
        player.changeSpeedUp(a);
        GameMovement.Instance.cameraSpeed += a;
        }

    }
    public void ChangeDownSpeed()
    {
        if (GameMovement.Instance.cameraSpeed <= 3)
        {
            GameMovement.Instance.cameraSpeed = 2;

        }
        else
        {
            GameMovement.Instance.cameraSpeed -= 2;
        }
    }
    void Update()
    {
        if (!startG&&Input.GetKeyDown(KeyCode.Space))
        {
            startG = true;


        }
        if (startG)
        {
            timer += Time.fixedDeltaTime*.12f;
            ChangeUpSpeed();
        }
    }
}
