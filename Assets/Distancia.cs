using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Distancia : MonoBehaviour
{
    [SerializeField]
    private Transform checkPoint;
    [SerializeField]
    private TextMeshProUGUI  distanciaText;
    private float distancia;
    public bool distanciaVisible;



  

    private void FixedUpdate()
    {
        if (!distanciaVisible) 
        {
            distanciaText.text = " 0.0 " + "Mts";
        }
        else
        {
            distancia = Vector2.Distance(transform.position, checkPoint.position);
            //distancia = (transform.position.x + checkPoint.transform.position.x);
            distanciaText.text = distancia.ToString("F1") + "Mts";

        }

       
    }

}
