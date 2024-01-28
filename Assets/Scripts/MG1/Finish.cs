using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static Finish Instance;

    public bool finished;


    private void Update()
    {
        if (finished)
        {

            finished = false;
        }    
    }

    public void End()
    {

    }

}
