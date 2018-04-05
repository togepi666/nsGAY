using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
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
		
		GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Force);
		if (interval > 2)
		{
			GetComponent<Rigidbody>().AddRelativeTorque(girlRotation, ForceMode.Force);
			interval = 0;
		}
		
	}

	void OnCollisionEnter(Collision turn)
	{
		if (turn.gameObject)
		{
		}
	}
}
