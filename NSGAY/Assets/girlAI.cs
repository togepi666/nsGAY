using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class girlAI : MonoBehaviour
{
	private float girlTurn;
	private float girlMotion;
	Vector3 girlRotation;

	// Use this for initialization
	void Start ()
	{

		girlMotion = 15f;

	}
	
	// Update is called once per frame
	void Update ()
	{

		girlTurn = Random.Range(-180f, 180f);
		girlRotation = new Vector3(0f, girlTurn, 0f);
		
		GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f,0f,girlMotion), ForceMode.Force);

	}

	void OnCollisionEnter(Collision turn)
	{
		if (turn.gameObject)
		{
			GetComponent<Rigidbody>().AddRelativeTorque(girlRotation, ForceMode.Force);
		}
	}
}
