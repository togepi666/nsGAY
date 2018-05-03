using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using Random = UnityEngine.Random;

public class girlAI : MonoBehaviour
{
	private Animator _animCont;
	private bool _standUp;
	private float girlTurn;
	private float girlMotion;
	Vector3 girlRotation;
	private float interval;

	private int ranNum = 0;
	private Vector3 _previousPos;
	private Vector3 _lastPos;

	private Vector3[] locations;
	// Use this for initialization
	void Start ()
	{
		_animCont = GetComponent<Animator>();
		interval = 0;
		girlMotion = 2f;
		locations= new Vector3[5];
		locations[0] = new Vector3(-8,0,0);
		locations[1] = new Vector3(7,0,5);
		locations[2] = new Vector3(-7,0,-8);
		locations[3] = new Vector3(18,0,-10);
		locations[4] = new Vector3(-5,0,-27);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		_previousPos = transform.position;
	
//		Vector3  direction =
		//	new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
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
					transform.position= Vector3.MoveTowards(transform.position, locations[0], .15f);
				//	transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[0], .1f, .1f);
					transform.LookAt(locations[0]);
					transform.Rotate(new Vector3(0, -90, 0));

					break;
				case 2: //transform.position = Vector3.MoveTowards(transform.position, locations[1], .5f);
					//GetComponent<Rigidbody>().AddForce(locations[1]-transform.position,ForceMode.Acceleration);
					transform.position = Vector3.MoveTowards(transform.position, locations[1], .15f);
				//	transform.rotation = Quaternion.LookRotation(transform.position,locations[1]);
				//	transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[1], .1f, .1f);
					transform.LookAt(locations[1]);
					transform.Rotate(new Vector3(0, -90, 0));




					break;
				case 3: //transform.position = Vector3.MoveTowards(transform.position, locations[2], .5f);
					//GetComponent<Rigidbody>().AddForce(locations[2]-transform.position,ForceMode.Acceleration);
					transform.position = Vector3.MoveTowards(transform.position, locations[2], .15f);
				//	transform.rotation = Quaternion.LookRotation(transform.position,locations[2]);
					//transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[2], .1f, .1f);
					transform.LookAt(locations[2]);
					transform.Rotate(new Vector3(0, -90, 0));



					break;
				case 4: //transform.position = Vector3.MoveTowards(transform.position, locations[3], .5f);
					//GetComponent<Rigidbody>().AddForce(locations[3]-transform.position,ForceMode.Acceleration);
					transform.position = Vector3.MoveTowards(transform.position, locations[3], .15f);
				//	transform.rotation = Quaternion.LookRotation(transform.position,locations[3]);
					//transform.eulerAngles = Vector3.RotateTowards(transform.position, locations[3], .1f, .1f);
					transform.LookAt(locations[3]);
					transform.Rotate(new Vector3(0, -90, 0));



					break;
				case 5:// transform.position = Vector3.MoveTowards(transform.position, locations[4], .5f);
					//GetComponent<Rigidbody>().AddForce(locations[4]-transform.position,ForceMode.Acceleration);
					GetComponent<Rigidbody>().position = Vector3.MoveTowards(transform.position, locations[4], .15f);
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

		//_lastPos = _previousPos;
		GirlMovementAnim();
		Debug.Log((transform.position-_previousPos).normalized);
	}

	void GirlMovementAnim()
	{
		Debug.Log(_animCont.GetBool("hitByBullet"));
		if ((transform.position-_previousPos).normalized != Vector3.zero)
		{
			_animCont.SetBool("walking",true);
		}

		if ((transform.position-_previousPos).normalized == Vector3.zero)
		{
			_animCont.SetBool("walking", false);
		}
		/*if (GetComponent<StrikeScript>().GirlHit)
		{
			
		}*/
	}

	void OnCollisionEnter(Collision turn)
	{
		if (turn.gameObject.CompareTag("Bullet"))
		{
			_animCont.SetBool("hitByBullet", true);
		}

		if (!turn.gameObject.CompareTag("floor") && !turn.gameObject.CompareTag("Bullet"))
		{
			if (_animCont.GetBool("hitByBullet"))
			{
				_animCont.SetBool("hitByBullet", false);
			}
		}
	}
	void OnCollisionStay(Collision other){
	if(!other.gameObject.CompareTag("floor"))
	{
		//Vector3.Distance()
		
	    GetComponent<Rigidbody>().AddForce(Vector3.zero - transform.position);
	}
	}
}
