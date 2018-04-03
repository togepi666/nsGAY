using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
	public bool crashed;

	public float currentTime = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (crashed)
		{
			currentTime += Time.deltaTime;
		}

		if (currentTime > 3)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		crashed = true;
	}
}
