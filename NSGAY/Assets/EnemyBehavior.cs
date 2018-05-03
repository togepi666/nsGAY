using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class EnemyBehavior : MonoBehaviour
{
	public GameObject mainCharacter;
    // Use this for initialization
	public GameObject explosion;
	public GameObject explosionV2;
	public bool hasPreTarget;
	public bool hasPreTarget3;
	public GameObject preTarget;
	public GameObject pretarget3;
    Material mat;

    public Color afterHit;

	public bool alive = true;

	public float speed = 5f;

	public float currentTime = 0;

	public int movementType = 0;

    AudioSource audio;
    public AudioClip ouch;
	// Use this for initialization
	void Start () {

		preTarget = GameObject.Find("PreTarget");
		pretarget3 = GameObject.Find("PreTarget3");
		mainCharacter = GameObject.Find("Girl");
		speed = Random.RandomRange(.7f, 1.5f);
        mat = GetComponentInChildren<Renderer>().material;
		explosion = Resources.Load("ExplosionParticles") as GameObject;
		explosionV2 = Resources.Load("ExplosionParticlesV2") as GameObject;
    }
	
	// Update is called once per frame
	void Update ()
	{
		if (hasPreTarget)
		{
			mainCharacter = preTarget;
		}else if (hasPreTarget3)
		{
			mainCharacter = preTarget;
		}
		else
		{
			mainCharacter = GameObject.Find("Girl");
		}
		
        audio = GetComponent<AudioSource>();
		if (alive)
		{
		transform.LookAt(mainCharacter.transform);
			if (movementType == 0)
			{
				transform.LookAt(mainCharacter.transform);
				transform.position = Vector3.MoveTowards(transform.position, mainCharacter.transform.position, 0.03f*speed);
			
				
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
		if (other.gameObject.CompareTag("PreTarget"))
		{
			if (hasPreTarget)
			{
				hasPreTarget = false;
			}

			if (hasPreTarget3)
			{
				hasPreTarget3 = false;
			}
		}
		if (other.gameObject.CompareTag("Bullet"))
		{
            if (alive)
            {
                audio.PlayOneShot(ouch);
            }
			Debug.Log("Should be dead.");
			//Add code to change which particle effect to play. Currently too big for other alien.
			if (movementType == 0)
			{
				GameObject boom = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
				boom.transform.SetParent(this.transform);
			}
			else
			{
				GameObject boom = Instantiate(explosionV2, this.transform.position, Quaternion.identity) as GameObject;
				boom.transform.SetParent(this.transform);
			}
		
			GetComponent<Rigidbody>().useGravity = true;
			alive = false;
			//GetComponent<ParticleSystem>().enableEmission = true;

			mat.color = afterHit;
		}
	}
    
}
