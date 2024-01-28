using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float velocityMove;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcesingMove();
    }

    void ProcesingMove()
    {
        //Logica de Movimiento
        float inputMovement = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputMovement * velocityMove, rb.velocity.y);
    }
}
