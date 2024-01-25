using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMaster1 : MonoBehaviour
{
    public static GMaster1 Instance;

    public bool startG;
    [SerializeField] float timer;
    

    private void Awake()
    {
        Instance = this;
        timer = 0;
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

            timer += Time.fixedDeltaTime;
        }
    }
}
