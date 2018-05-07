using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlGaze : MonoBehaviour
{
	public float GirlGazeRadius;
	[Range(0, 360)] public float GirlGazeAngle;
	public Transform MeshMover;
	public Transform TransfomersMore;
	public Transform[] CameraTransform = new Transform[3];


	private bool _oneShot;
	private float _currentRayAngle;
	private float _minAngleBound,_maxAngleBound;
	private float _minNegativeBound, _maxNegativeBound;
	private CameraSwitching _camController;
	private List<Transform> BulletTransforms;
	private Vector3 _currentTransformRotation;

	private void Start()
	{
		_camController = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraSwitching>();
		//_gazeSpotlight = GameObject.FindGameObjectWithTag("Projector").GetComponent<Projector>();
	}

	void AdjustBounds()
	{
		/*_currentTransformRotation = transform.eulerAngles;
		_currentTransformRotation.y = Mathf.Clamp(_currentTransformRotation.y, 0, 360);
		transform.rotation = Quaternion.Euler(_currentTransformRotation);*/
		if (_camController.ComputerCamEnabled)
		{
			GirlGazeRadius = Mathf.Abs(CameraTransform[0].position.z - transform.position.z)
			                 + Mathf.Abs(CameraTransform[0].position.x - transform.position.x) / 2;
		}

		if (_camController.PhoneCamEnabled)
		{
			GirlGazeRadius = Mathf.Abs(CameraTransform[1].position.z - transform.position.z)
			 + Mathf.Abs(CameraTransform[1].position.x - transform.position.x)/2;
		}

		if (_camController.EchoCamEnabled)
		{
			GirlGazeRadius = Mathf.Abs(CameraTransform[2].position.z - transform.position.z)
			                 + Mathf.Abs(CameraTransform[2].position.x - transform.position.x)/2;
		}
	}

	private void Update()
	{
		AdjustBounds();
		MeshMover.position = transform.position;
		MeshMover.rotation = transform.rotation;
	}

	private void LateUpdate()
	{
    TransfomersMore.SetParent(MeshMover);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, GirlGazeRadius);
	}
}




