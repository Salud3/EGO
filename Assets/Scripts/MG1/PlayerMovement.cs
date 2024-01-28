using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask ContactoInferior;
    
    [Header("Movimiento")]
    [SerializeField] float gravity = 1f;
    [SerializeField] float speed;

    [Header("Salto")]
    [SerializeField] bool canJump;
    [SerializeField] bool jumping;
    [SerializeField] float jumpBufferTime = 1.5f;
    [SerializeField] float jumpBufferTim;

    [Header("Invulnerabilidad")]
    [SerializeField] bool invulnerable = false;
    [SerializeField] float invultimebuffer = 1.5f;
    [SerializeField] float bufferinvul;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (invulnerable)
        {
            bufferinvul += Time.fixedDeltaTime;
            if (bufferinvul > invultimebuffer)
            {
                invulnerable = false;
                bufferinvul = 0;
            }
        }

        if (jumping && GMaster1.Instance.startG)
        {
            jumpBufferTim -= Time.deltaTime;
            if (jumpBufferTim < 0)
            {
                jumping = false;
                jumpBufferTim = jumpBufferTime; 
            }

        }
        if (Input.GetKeyDown(KeyCode.Space) && !jumping && canJump && GMaster1.Instance.startG)
        {
            jumping = true;

        }else if (Input.GetKeyUp(KeyCode.Space) && GMaster1.Instance.startG)
        {
            jumping = false;
            jumpBufferTim = jumpBufferTime;

        }
    }

    private void FixedUpdate()
    {
        DetectCollisions();

        if (jumping && GMaster1.Instance.startG)
        {
            //rg.MovePosition(transform.position + new Vector3(speed, jumpForce) * Time.deltaTime);
            rg.velocity = new Vector2(GMaster1.Instance.Speed,jumpForce);
            
        }
        else if (!jumping && GMaster1.Instance.startG)
        {
            rg.MovePosition(transform.position + new Vector3(GMaster1.Instance.Speed, -gravity) * Time.deltaTime);
        }
    }


    void DetectCollisions()
    {
        float rayLegth = .7f;

        Ray2D ray = new Ray2D(new Vector2(transform.position.x, transform.position.y) - new Vector2(0, .5f), Vector2.down);

        Debug.DrawRay(ray.origin, ray.direction * rayLegth, Color.yellow);

        bool FLOOR = Physics2D.Raycast(ray.origin, ray.direction, rayLegth, ContactoInferior);

        if (FLOOR)
        {
            canJump = true;

        }else
        {
            canJump = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            GMaster1.Instance.ChangeDownSpeed();
            invulnerable = true;
        }
        if (collision.tag == "Finished")
        {
            GMaster1.Instance.finished = true;
        }

    }

}
