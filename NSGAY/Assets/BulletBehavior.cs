﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	public bool crashed;
	public bool justShot = true;
	public float currentTime = 0;

	public float totalTime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		totalTime = +Time.deltaTime;
		if (totalTime > .3f)
		{
			justShot = false;
		}
		if (crashed)
		{
			currentTime += Time.deltaTime;
		}

		if (currentTime > .5f)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if(!other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("CameraLocation"))
			crashed = true;
	}
}
