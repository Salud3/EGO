using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Distancia : MonoBehaviour

{
    public static Distancia Instance;
    [SerializeField]
    private Transform Dentadura;
    [SerializeField]
    private TextMeshProUGUI  distanciaText;
    private float distancia; public float Dist { get { return distancia; } }
    public bool distanciaVisible;
    public Animator animator;

    private void Start()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(enumerator());
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(3f);
        animator.SetTrigger("In");
    }
    private void FixedUpdate()
    {
        if (!distanciaVisible) 
        {
            distanciaText.text = " 0.0 " + "Mts";
        }
        else
        {
            distancia = Vector2.Distance(transform.position, Dentadura.position);
            //distancia = (transform.position.x + checkPoint.transform.position.x);
            distanciaText.text = distancia.ToString("F1") + "Mts";

        }

       
    }

}
