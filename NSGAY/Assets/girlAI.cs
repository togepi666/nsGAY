using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlAI : MonoBehaviour
{
	private float girlTurn;
	private float girlMotion;
	Vector3 girlRotation;

	private float interval;
	// Use this for initialization
	void Start ()
	{
		interval = 0;
		girlMotion = 9f;

	}
	
	// Update is called once per frame
	void Update ()
	{
		interval += Time.deltaTime;
		girlTurn = Random.Range(-180f, 180f);
		girlRotation = new Vector3(0f, girlTurn, 0f);
		
		if (interval > .5f)
		{
			GetComponent<Rigidbody>().AddRelativeTorque(girlRotation *2, ForceMode.Force);
			interval = 0;
			GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);

		}
		
	}

	void OnCollisionEnter(Collision turn)
	{
		if (turn.gameObject)
		{
		}
	}
}
