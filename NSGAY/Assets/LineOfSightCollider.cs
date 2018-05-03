using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightCollider : MonoBehaviour
{
	public bool StrikeOnce;
	private Animator _anihoemator;
	private girlGaze _gassy;
	void Start ()
	{
		_gassy = transform.parent.gameObject.GetComponent<girlGaze>();
		_anihoemator = transform.parent.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			if(other.gameObject.GetComponent<BulletBehavior>().justShot)
				_anihoemator.SetBool("walking",false);
				_anihoemator.SetTrigger("SpottedPlayer");
			_gassy.gameObject.GetComponent<StrikeScript>().strikes--;
			StrikeOnce = true;
		}
		
		/*if (bulletTran.gameObject.GetComponent<BulletBehavior>().justShot == true)
		{
			gameObject.GetComponent<StrikeScript>().strikes--;
			bulletTran.gameObject.GetComponent<BulletBehavior>().justShot = false;
		}*/
	}

	private void LateUpdate()
	{
		
	}
}
