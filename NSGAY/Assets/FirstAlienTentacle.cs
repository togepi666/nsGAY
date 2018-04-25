using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAlienTentacle : MonoBehaviour
	
{
	private float defaultPos = 1.605509f;
	private Rigidbody rb;
	public Vector3 targetPosition;
	public int AlienLayerMask;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		

	}

	void FixedUpdate ()
	{
		//rb.ResetInertiaTensor();
	//rb.velocity = new Vector3(rb.velocity.x,Time.deltaTime*-10f,rb.velocity.z);
		if (rb.position.x > 0 && rb.position.y > 0)
		{
			rb.constraints = RigidbodyConstraints.FreezePositionY;
		}
	//rb.rotation = Quaternion.Euler(10,0,0);
		//targetPosition = new Vector3(transform.position.x,-1.4f,transform.position.z);
		//Vector3 distance = targetPosition - transform.position;
		//distance.x = 0;
		///distance.z = 0;
		///Vector3 targetVelocity = Vector3.ClampMagnitude(2.5f * distance, 5f);
		//Vector3 error = targetVelocity - rb.velocity;
		//Vector3 force = Vector3.ClampMagnitude(5f * error, 12f);
		//rb.AddForce(force);
		/*if (transform.position.y < 1.42f)
		{
			rb.constraints = RigidbodyConstraints.FreezePositionY;
			//transform.position = new Vector3(transform.position.x,defaultPos,transform.position.z);
			//_bottomCenterRb.constraints = RigidbodyConstraints.FreezePositionY;
		}*/


	}
}
