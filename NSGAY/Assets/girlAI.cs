using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
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
	private CameraSwitching _switch;
	private Vector3 _previousPos;
	private Vector3 _lastPos;

	private Vector3[] locations;

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
		_switch = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraSwitching>();

	}
	
	void Update ()
	{
		_previousPos = transform.position;
		
		interval += Time.deltaTime;
		
		if (interval > 3f)
		{
			ranNum = Random.Range(0, 6);
			interval = 0;
		}

		switch (ranNum)
		{
				
				case 1: 
					transform.position= Vector3.MoveTowards(transform.position, locations[0], .1f);
					transform.LookAt(locations[0]);
					transform.Rotate(new Vector3(0, -90, 0));

					break;
				case 2: 
					transform.position = Vector3.MoveTowards(transform.position, locations[1], .05f);
					transform.LookAt(locations[1]);
					transform.Rotate(new Vector3(0, -90, 0));




					break;
				case 3: 
					transform.position = Vector3.MoveTowards(transform.position, locations[2], .1f);
					transform.LookAt(locations[2]);
					transform.Rotate(new Vector3(0, -90, 0));



					break;
				case 4: 
					transform.position = Vector3.MoveTowards(transform.position, locations[3], .05f);
					transform.LookAt(locations[3]);
					transform.Rotate(new Vector3(0, -90, 0));



					break;
				case 5:
					transform.position = Vector3.MoveTowards(transform.position, locations[4], .05f);
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
		if (!turn.gameObject.CompareTag("floor") && !turn.gameObject.CompareTag("Bullet"))
		{
			if (_animCont.GetBool("hitByBullet"))
			{
				_animCont.SetBool("walking", false);
				_animCont.SetBool("hitByBullet", false);
			}
		}
	}
	void OnCollisionStay(Collision other){
	if(!other.gameObject.CompareTag("floor"))
	{
		//Vector3.Distance()
		
	 //   GetComponent<Rigidbody>().AddForce(Vector3.zero - transform.position);
	}
	}
}
