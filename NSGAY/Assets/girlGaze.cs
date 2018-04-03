using System.Collections;
using System.Collections.Generic;
using UnityEditor.Graphs;
using UnityEngine;

public class girlGaze : MonoBehaviour
{

	public Transform Girl;

	private bool _compCamTriggered, _phoneCamTriggered, _echoCamTriggered;
	private CameraSwitching _camSwitch;
	private GameObject _camController;
	private void Start()
	{
		_camController = GameObject.FindGameObjectWithTag("CameraController");
		_camSwitch = _camController.GetComponent<CameraSwitching>();
	}

	private void FixedUpdate()
	{
		LayerMask compCamLayerMask = LayerMask.GetMask("Computer");
		LayerMask phoneCamLayerMask = LayerMask.GetMask("Phone");
		LayerMask echoCamLayerMask = LayerMask.GetMask("Echo");
		Ray girlRay = new Ray(transform.position,Girl.position);
		RaycastHit compOnHit,phoneOnHit,echoOnHit;
		if (Physics.Raycast(girlRay, out compOnHit, compCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 0)
			{
				//GameManager class that contains bool that tracks the CompCam hit as true
			}
		}
		if (!Physics.Raycast(girlRay, out compOnHit, compCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 0)
			{
				//GameManager class that contains bool that tracks the CompCam hit as false
			}
		}
		if (Physics.Raycast(girlRay, out phoneOnHit, phoneCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 1)
			{
				//GameManager class that contains bool that tracks the PhoneCam hit as true
			}
		}
		if (!Physics.Raycast(girlRay, out phoneOnHit, phoneCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 1)
			{
                //GameManager class that contains bool that tracks the PhoneCam hit as false
			}
		}
		if (Physics.Raycast(girlRay, out echoOnHit, echoCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 2)
			{
				//GameManager class that contains bool that tracks the EchoCam hit as true
			}
		}
		if (!Physics.Raycast(girlRay, out echoOnHit, echoCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 2)
			{
				//GameManager class that contains bool that tracks the EchoCam hit as false
			}
		}
		
	}
}
