using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightCollider : MonoBehaviour
{
	public bool BulletEnteredLineOfSight;
	private Animator _anihoemator;
	private girlGaze _gassy;
	private CameraSwitching _switch;
	void Start ()
	{
		_gassy = transform.parent.gameObject.GetComponent<girlGaze>();
		_switch = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraSwitching>();
		_anihoemator = transform.parent.gameObject.GetComponent<Animator>();
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Bullet") && !BulletEnteredLineOfSight)
		{
			transform.parent.LookAt(_gassy.CameraTransform[_switch.CurrentMaterialIndex].position);
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
