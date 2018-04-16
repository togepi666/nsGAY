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

	public int movementType;
	// Use this for initialization
	void Start () {
		mainCharacter = GameObject.Find("Girl");
		speed = Random.RandomRange(.7f, 1.5f);
		movementType = Random.Range(0, 3);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (alive)
		{
			if (movementType == 0)
			{
				transform.LookAt(mainCharacter.transform);
				transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, 0.03f*speed);
				transform.position = new Vector3(transform.position.x +Mathf.Sin(Time.time*2) *.1f, transform.position.y+Mathf.Sin(Time.time*2) *.1f,transform.position.z);
			
			}
			if (movementType == 1)
			{
				transform.LookAt(mainCharacter.transform);
				transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, 0.03f*speed);
			
			}

			if (movementType == 2)
			{
				transform.LookAt(mainCharacter.transform);
				transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, 0.03f*speed);
				transform.position = new Vector3(transform.position.x +Mathf.Sin(Time.time*4) *.1f, transform.position.y-Mathf.Sin(Time.time+1) *.1f,transform.position.z );
			
			}
				
		}
		else
		{
			currentTime += Time.deltaTime;
			transform.localScale /= 1.05f;
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
