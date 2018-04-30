using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshResizing : MonoBehaviour
{
	public GameObject ProjectedMesh;
	
	private Camera _projectCam;
	private girlGaze _gaze;
	private Projector _meshProjector;
	private Renderer _projectedMeshRenderer;
	void Start ()
	{
		_projectedMeshRenderer = ProjectedMesh.GetComponent<Renderer>();
		_projectCam = GetComponentInChildren<Camera>();
		_gaze = GameObject.FindGameObjectWithTag("Player").GetComponent<girlGaze>();
		_meshProjector = GetComponentInChildren<Projector>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		ProjectedMesh.transform.localScale = new Vector3(_gaze.GirlGazeRadius/5,ProjectedMesh.transform.localScale.y,_gaze.GirlGazeRadius/5);
		_projectCam.orthographicSize = _gaze.GirlGazeRadius;
		_meshProjector.orthographicSize = _gaze.GirlGazeRadius;
	}
}
