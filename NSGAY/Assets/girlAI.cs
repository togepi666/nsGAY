using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class girlAI : MonoBehaviour
{
	private float girlTurn;
	private float girlMotion;
	Vector3 girlRotation;
	public float currentTime = 0;

	// Use this for initialization
	void Start ()
	{

		girlMotion = 15f;

	}
	
	// Update is called once per frame
	void Update ()
	{
		currentTime+=Time.deltaTime;
		if (currentTime > 3)
		{
			girlTurn = Random.Range(-100f, 100f);
			currentTime = 0;
			girlRotation = new Vector3(0f, girlTurn, 0f);
			

		}
		GetComponent<Rigidbody>().AddRelativeTorque(girlRotation, ForceMode.Force);

		GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0f,0f,girlMotion), ForceMode.Force);

		//girlTurn = Random.Range(-180f, 180f);
		
		
	}

	void OnCollisionEnter(Collision turn)
	{
		if (turn.gameObject)
		{
		}
	}
}
