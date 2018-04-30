using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class girlAI : MonoBehaviour
{
	private float girlTurn;
	private float girlMotion;
	Vector3 girlRotation;
	private float interval;

	private int ranNum = 0;

	private Vector3[] locations;
	// Use this for initialization
	void Start ()
	{
		interval = 0;
		girlMotion = 2f;
		locations= new Vector3[5];
		locations[0] = new Vector3(-4,0,0);
		locations[1] = new Vector3(5,0,5);
		locations[2] = new Vector3(-7,0,-8);
		locations[3] = new Vector3(9,0,-4);
		locations[4] = new Vector3(-5,0,9);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3  direction =
			new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
	  //  transform.rotation = Quaternion.Slerp(transform.rotation,(transform.position + GetComponent<Rigidbody>().velocity), 1);
		
		interval += Time.deltaTime;
		//girlTurn = Random.Range(-180f, 180f);
		//girlRotation = new Vector3(0f, girlTurn, 0f);
		
		if (interval > 2f)
		{
			ranNum = Random.Range(0, 6);
	//		GetComponent<Rigidbody>().AddRelativeTorque(girlRotation *2, ForceMode.Force);
			interval = 0;
		//	GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);

		}

		switch (ranNum)
		{
				
				case 1: //transform.position = Vector3.MoveTowards(transform.position, locations[0], .5f);
					//	GetComponent<Rigidbody>().AddForce(locations[0]-transform.position,ForceMode.Acceleration);
					transform.position = Vector3.MoveTowards(transform.position, locations[0], .1f);
				//	transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[0], .1f, .1f);
					transform.LookAt(locations[0]);
					transform.Rotate(new Vector3(0, -90, 0));

					break;
				case 2: //transform.position = Vector3.MoveTowards(transform.position, locations[1], .5f);
					//GetComponent<Rigidbody>().AddForce(locations[1]-transform.position,ForceMode.Acceleration);
					transform.position = Vector3.MoveTowards(transform.position, locations[1], .1f);
				//	transform.rotation = Quaternion.LookRotation(transform.position,locations[1]);
				//	transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[1], .1f, .1f);
					transform.LookAt(locations[1]);
					transform.Rotate(new Vector3(0, -90, 0));




					break;
				case 3: //transform.position = Vector3.MoveTowards(transform.position, locations[2], .5f);
					//GetComponent<Rigidbody>().AddForce(locations[2]-transform.position,ForceMode.Acceleration);
					transform.position = Vector3.MoveTowards(transform.position, locations[2], .1f);
				//	transform.rotation = Quaternion.LookRotation(transform.position,locations[2]);
					//transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[2], .1f, .1f);
					transform.LookAt(locations[2]);
					transform.Rotate(new Vector3(0, -90, 0));



					break;
				case 4: //transform.position = Vector3.MoveTowards(transform.position, locations[3], .5f);
					//GetComponent<Rigidbody>().AddForce(locations[3]-transform.position,ForceMode.Acceleration);
					transform.position = Vector3.MoveTowards(transform.position, locations[3], .1f);
				//	transform.rotation = Quaternion.LookRotation(transform.position,locations[3]);
					//transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[3], .1f, .1f);
					transform.LookAt(locations[3]);
					transform.Rotate(new Vector3(0, -90, 0));



					break;
				case 5:// transform.position = Vector3.MoveTowards(transform.position, locations[4], .5f);
					//GetComponent<Rigidbody>().AddForce(locations[4]-transform.position,ForceMode.Acceleration);
					transform.position = Vector3.MoveTowards(transform.position, locations[4], .1f);
				//	transform.rotation = Quaternion.LookRotation(transform.position,locations[4]);
					//transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[4], .1f, .1f);
					transform.LookAt(locations[4]);
					transform.Rotate(new Vector3(0, -90, 0));

					break;
		}

		foreach (var targetLoc in locations)
		{
			if (targetLoc.z == transform.position.z && targetLoc.x == transform.position.x)
				interval = 3;
		}

		
	}

	void OnCollisionEnter(Collision turn)
	{
		if (turn.gameObject)
		{
		}
	}
	void OnCollisionStay(Collision other){
	if(!other.gameObject.CompareTag("floor")){
	    GetComponent<Rigidbody>().AddForce(Vector3.zero - transform.position);
	}
	}
}
