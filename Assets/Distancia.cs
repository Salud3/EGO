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



  

    private void Update()
    {
        distancia = (transform.position.x + checkPoint.transform.position.x);
        distanciaText.text = "Distancia:" + distancia.ToString("F1") + "Mts";


       
    }

}
