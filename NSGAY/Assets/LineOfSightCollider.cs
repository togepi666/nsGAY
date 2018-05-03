using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightCollider : MonoBehaviour
{

	private girlGaze _gassy;
	void Start ()
	{
		_gassy = transform.parent.gameObject.GetComponent<girlGaze>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			if(other.gameObject.GetComponent<BulletBehavior>().justShot)
			_gassy.gameObject.GetComponent<StrikeScript>().strikes--;
		}
		
		/*if (bulletTran.gameObject.GetComponent<BulletBehavior>().justShot == true)
		{
			gameObject.GetComponent<StrikeScript>().strikes--;
			bulletTran.gameObject.GetComponent<BulletBehavior>().justShot = false;
		}*/
	}
}
