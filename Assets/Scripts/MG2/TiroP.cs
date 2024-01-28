using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]


public class TiroP : MonoBehaviour
{
	[SerializeField]Cable cable;
   public Transform pivot;
	public float springRange;
	public float maxVel;
	public CinemachineVirtualCamera virtualCamera;
	public Distancia distance;

	Rigidbody2D rb;
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
		rb.bodyType = RigidbodyType2D.Kinematic;
	}

	bool canDrag = true;
	Vector3 dis;
	
	public void OnMouseDrag()
	{
        if (!canDrag)
            return;

        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dis = pos - pivot.position;
        dis.z = 0;
        if (dis.magnitude > springRange)
        {
            dis = dis.normalized * springRange;
        }
        transform.position = dis + pivot.position;
	    cable.ActualizarPosicion(pos);
        cable.ActualizarRotacion();
        cable.ActualizarTamaño();
	   
    }

	public void OnMouseUp()
	{
		if (!canDrag)
			return;
		canDrag = false;

		rb.bodyType = RigidbodyType2D.Dynamic;
		//rb.velocity = -dis.normalized * maxVel * dis.magnitude / springRange;
		rb.AddForce((-dis.normalized * maxVel * dis.magnitude / springRange), ForceMode2D.Impulse);
	}


    private void FixedUpdate()
    {
        if (!canDrag)
		{
			distance.distanciaVisible = true;
			StartCoroutine(AfilliateCamera());
			rb.velocity -= new Vector2 (.05f, 0);
			Animator a = rb.GetComponent<Animator>();
			a.SetTrigger("Lanzado");

			if(rb.velocity.y <= 0.1 && rb.velocity.x <= 0.1)
			{
				rb.velocity = new Vector2(0, -rb.gravityScale);
			}
		}

    }

	public IEnumerator AfilliateCamera()
	{
        yield return new WaitForSeconds(0.25f);
		virtualCamera.Follow = this.gameObject.transform;
		virtualCamera.LookAt = this.gameObject.transform;
        yield return new WaitForSeconds(0.1f);
    }

}

