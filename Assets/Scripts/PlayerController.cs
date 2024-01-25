using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Rigidbody2D rb;

    public float velocityMove;

    void Update()
    {
        //rb = GetComponent<Rigidbody2D>();

        ProcesingMove();
    }

    void ProcesingMove()
    {
        //Logica de Movimiento
        float inputMovement = Input.GetAxis("Horizontal");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(inputMovement * velocityMove, rb.velocity.y);
    }
}
