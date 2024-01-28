using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    public SpriteRenderer finalCable;

    private Vector2 posicionOriginal;
    private Vector2 tamañoOriginal;
    
    void Start()
    {
        posicionOriginal = transform.position;
        tamañoOriginal = finalCable.size;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Reiniciar();
        }
    }

   /* private void OnMouseDrag()
    {
        ActualizarPosicion();
        ActualizarRotacion();
        ActualizarTamaño();
    }*/


    public void ActualizarPosicion(Vector2 pos)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }

    public void ActualizarRotacion()
    {
        Vector2 posicionActual = transform.position;
        Vector2 puntoOrigen = transform.parent.position;

        Vector2 direccion = posicionActual - puntoOrigen;

        float angulo = Vector2.SignedAngle(Vector2.right * (transform.lossyScale-new Vector3(0.5f,0.5f,0.5f)), direccion);

        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }

    public void ActualizarTamaño()
    {
        Vector2 posicionActual = transform.position;
        Vector2 puntoOrigen = transform.parent.position;

        float distancia = Vector2.Distance(posicionActual, puntoOrigen);

        finalCable.size = new Vector2(distancia, finalCable.size.y);
    }

    public void Reiniciar()
    {
        transform.position = posicionOriginal;
        transform.rotation = Quaternion.identity;
        finalCable.size = tamañoOriginal;
    }

    public void Conectar()
    {
        Destroy(this);
    }
}
