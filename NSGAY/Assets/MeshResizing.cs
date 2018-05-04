using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshResizing : MonoBehaviour
{
	public GameObject ProjectedMesh;
	
	private Camera _projectCam;
	private girlGaze _gaze;
	private Projector _meshProjector;
	private Vector3 _clampedAngles;
	public Transform MeshCollider;
	void Start ()
	{
		_projectCam = GetComponentInChildren<Camera>();
		_gaze = GameObject.FindGameObjectWithTag("Player").GetComponent<girlGaze>();
		_meshProjector = GetComponentInChildren<Projector>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = new Vector3(_gaze.gameObject.transform.position.x-1,transform.position.y,_gaze.gameObject.transform.position.z+1);
		_clampedAngles = _gaze.gameObject.transform.eulerAngles;
		_clampedAngles.y = Mathf.Clamp(_clampedAngles.y,0, 360);
		transform.rotation = Quaternion.Euler(0,_clampedAngles.y,0);
		MeshCollider.transform.localScale =new Vector3(_gaze.GirlGazeRadius/5,MeshCollider.transform.localScale.y,_gaze.GirlGazeRadius/5);
		ProjectedMesh.transform.localScale = new Vector3(_gaze.GirlGazeRadius/5,ProjectedMesh.transform.localScale.y,_gaze.GirlGazeRadius/5);
		_projectCam.orthographicSize = _gaze.GirlGazeRadius;
		_meshProjector.orthographicSize = _gaze.GirlGazeRadius;
	}
}
