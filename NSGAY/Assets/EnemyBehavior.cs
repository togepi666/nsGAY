using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class EnemyBehavior : MonoBehaviour
{
	public GameObject mainCharacter;
	// Use this for initialization

	public bool alive = true;

	public float speed = 5f;

	public float currentTime = 0;

	// Use this for initialization
	void Start () {
		mainCharacter = GameObject.Find("Girl");
		speed = Random.RandomRange(1, 1.5f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (alive)
		{
			transform.LookAt(mainCharacter.transform);
			transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, 0.03f*speed);
			transform.position = new Vector3(transform.position.x +Mathf.Sin(Time.time*2) *.1f, transform.position.y+Mathf.Sin(Time.time*2) *.1f,transform.position.z);
				
		}
		else
		{
			currentTime += Time.deltaTime;
			if (currentTime > 4)
			{
				Destroy(gameObject);
			}

		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			GetComponent<Rigidbody>().useGravity = true;
			alive = false;
		}
	}
}
