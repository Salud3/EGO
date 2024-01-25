using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask ContactoInferior;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float jumpBufferTime = 1.5f;
    [SerializeField] float jumpBufferTim;
    [SerializeField] bool jumping;
    [SerializeField] float speed;


    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (jumping && GMaster1.Instance.startG)
        {
            jumpBufferTim += Time.fixedDeltaTime;
            if (jumpBufferTim > jumpBufferTime)
            {
                jumping = false;
                jumpBufferTim = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.Space) && !jumping && canJump && GMaster1.Instance.startG)
        {
            jumping = true;

        }
        if (Input.GetKeyUp(KeyCode.Space) && GMaster1.Instance.startG)
        {
            jumping = false;

        }
    }

    private void FixedUpdate()
    {
        DetectCollisions();

        if (jumping && GMaster1.Instance.startG)
        {
            rg.MovePosition(transform.position + new Vector3(speed, jumpForce) * Time.deltaTime);
        }
        else if (!jumping && GMaster1.Instance.startG)
        {

            rg.MovePosition(transform.position + new Vector3(speed, -gravity) * Time.deltaTime);
        }
    }

    [SerializeField] bool canJump;

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
            changeSpeedD();
        }
    }

    void changeSpeedD()
    {
        if (speed <= 3)
        {
            speed = 2;

        }
        else
        {
            speed -= 2;
        }
    }
   public void changeSpeedUp(float a)
    {
        speed += a;
    }

}
