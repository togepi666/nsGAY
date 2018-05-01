using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class EnemyBehavior : MonoBehaviour
{
	public GameObject mainCharacter;
    // Use this for initialization
	public GameObject explosion;
    Material mat;

    public Color afterHit;

	public bool alive = true;

	public float speed = 5f;

	public float currentTime = 0;

	public int movementType = 0;

	public int EnemyType;

	private float _yMultiplier = 1;
	// Use this for initialization
	void Start () {

		mainCharacter = GameObject.Find("Girl");
		speed = Random.RandomRange(.7f, 1.5f);
        mat = GetComponentInChildren<Renderer>().material;
		explosion = Resources.Load("ExplosionParticles") as GameObject;
    }
	
	// Update is called once per frame
	void Update ()
	{
		if (alive)
		{
			if (EnemyType == 1)
			{
				_yMultiplier = 0.01f;
			}
		transform.LookAt(mainCharacter.transform);
			if (movementType == 0)
			{
				transform.LookAt(mainCharacter.transform);
				transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, _yMultiplier*speed);
			
				
			}
			if (movementType == 1)
			{
				transform.LookAt(mainCharacter.transform);
				transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, 0.03f*speed);
				transform.position = new Vector3(transform.position.x +Mathf.Sin(Time.time*2 + 1) *.1f, transform.position.y+Mathf.Sin(Time.time*2) *.1f,transform.position.z);
			
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
			if (currentTime > 2)
			{
				Destroy(gameObject);
			}

		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			if (EnemyType == 0)
			{
				GetComponent<Rigidbody>().useGravity = true;
			}

			else
			{
				transform.GetChild(0).gameObject.GetComponent<Rigidbody>().drag = 0;
			}
			Debug.Log("Should be dead.");
			//Add code to change which particle effect to play. Currently too big for other alien.
			GameObject boom = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
			boom.transform.SetParent(this.transform);	
			alive = false;
			//GetComponent<ParticleSystem>().enableEmission = true;
			mat.color = afterHit;
		}
	}
    
}
