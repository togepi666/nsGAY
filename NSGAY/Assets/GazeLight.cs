using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeLight : MonoBehaviour
{
	private int _currentCamera;
	private CameraSwitching _camSwitch;
	private girlGaze _girlGaze;
	private Projector _gazeSpotlight;
	[SerializeField]private float _distToCurrentCam;
	private float[] _zCamTransforms = new float[3];
	void Start ()
	{
		_gazeSpotlight = GetComponent<Projector>();
		_camSwitch = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraSwitching>();
		_girlGaze = GameObject.FindGameObjectWithTag("Player").GetComponent<girlGaze>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		
	}
}
