using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMovement : MonoBehaviour
{
    public static GameMovement Instance;

    public float cameraSpeed;

    private void Start()
    {
        Instance = this;
    }
    private void FixedUpdate()
    {
        if (GMaster1.Instance.startG)
        {

            transform.position += new Vector3(cameraSpeed * Time.fixedDeltaTime, 0, 0);
        }

    }

}
