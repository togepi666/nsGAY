using System.Collections;
using System.Collections.Generic;
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
	{			Debug.Log("JustShot = " + justShot);

		totalTime +=Time.deltaTime;
		if (totalTime > .15f)
		{
			justShot = false;
		}
		if (crashed)
		{
			currentTime += Time.deltaTime;
		}

		if (totalTime > 5)
		{
			crashed = true;
		}
		if (currentTime > .5f)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		//Debug.Log(other.gameObject.tag);
		if(!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("CameraLocation") && !other.gameObject.CompareTag("Bullet"))
			crashed = true;
	}
}
