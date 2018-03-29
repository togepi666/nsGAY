using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class EnemyBehavior : MonoBehaviour
{
	public GameObject mainCharacter;

	public bool alive = true;

	public float speed = 0;
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
			transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, 0.05f * speed);
		}
	}

	void OnMouseClick()
	{
		Destroy(gameObject);
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
