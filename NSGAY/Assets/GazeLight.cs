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
		_zCamTransforms[0] = _camSwitch.DeskCamera.gameObject.transform.position.z;
		_zCamTransforms[1] = _camSwitch.PhoneCamera.gameObject.transform.position.z;
		_zCamTransforms[2] = _camSwitch.EchoCamera.gameObject.transform.position.z;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		_currentCamera = _camSwitch.CurrentMaterialIndex;
		_distToCurrentCam = _girlGaze.GirlGazeRadius;
		_gazeSpotlight.orthographicSize = _distToCurrentCam / 7.874015748f;
		transform.Translate(0,0,_distToCurrentCam - 10f);
	}
}
