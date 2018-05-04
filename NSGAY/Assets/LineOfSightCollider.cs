using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightCollider : MonoBehaviour
{
	public bool BulletEnteredLineOfSight;
	private Animator _anihoemator;
	private girlGaze _gassy;
	private girlAI _assy;
	void Start ()
	{
		_gassy = transform.parent.gameObject.GetComponent<girlGaze>();
		_assy = GameObject.FindGameObjectWithTag("Player").GetComponent<girlAI>();
		_anihoemator = transform.parent.gameObject.GetComponent<Animator>();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bullet") && !BulletEnteredLineOfSight)
		{
			_assy.ranNum = 6;
			_anihoemator.SetTrigger("SpottedPlayer");
			_gassy.gameObject.GetComponent<StrikeScript>().strikes--;
			BulletEnteredLineOfSight = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			if (!other.gameObject.GetComponent<BulletBehavior>().justShot && BulletEnteredLineOfSight)
			{
				BulletEnteredLineOfSight = false;
			}
		}
	}
}
