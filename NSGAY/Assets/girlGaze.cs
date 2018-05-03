using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlGaze : MonoBehaviour
{
	public float GirlGazeRadius;
	[Range(0, 360)] public float GirlGazeAngle;

	public LayerMask BulletLayerMask;
	public LayerMask[] DeviceLayerMask = new LayerMask[3];
	public List<Transform> BulletPos = new List<Transform>();
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
		_currentTransformRotation = transform.eulerAngles;
		_currentTransformRotation.y = Mathf.Clamp(_currentTransformRotation.y, 0, 360);
		transform.rotation = Quaternion.Euler(_currentTransformRotation);
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

	

	private void FixedUpdate()
	{
		//DetectCamera();
	}

	
	private void DetectCamera()
	{
        AdjustBounds();
		for (int i = 0; i < DeviceLayerMask.Length; i++)
		{
			Physics.OverlapSphere(transform.position, GirlGazeRadius, DeviceLayerMask[i]);
			Vector3 _gazeDirection = (CameraTransform[i].position - transform.position).normalized;
			if (Vector3.Angle(_gazeDirection, transform.forward) <= GirlGazeAngle/2)
			{
				float rayDistance = Vector3.Distance(transform.position, CameraTransform[i].position);
				if (Physics.Raycast(transform.position, _gazeDirection, rayDistance, DeviceLayerMask[i]))
				{
					Debug.DrawLine(transform.position, CameraTransform[i].position, Color.blue);
					RaycastHit bulletHit;
					List<Collider> colliders = new List<Collider>();
					colliders.AddRange(Physics.OverlapSphere(transform.position, GirlGazeRadius, BulletLayerMask));
					for (int j = 0; j < colliders.Count; j++)
					{
						var bulletTran = colliders[j].gameObject.transform;
						Vector3 bulletRayDirection = (bulletTran.position - transform.position).normalized;
						float bulletRayDist = Vector3.Distance(transform.position, bulletTran.position);
						if (Physics.Raycast(transform.position, bulletRayDirection, bulletRayDist, BulletLayerMask))
						{
							_oneShot = false;
							Debug.DrawLine(bulletTran.position, transform.position, Color.yellow);
							if (!_oneShot)
							{
								if (bulletTran.gameObject.GetComponent<BulletBehavior>().justShot)
								{
									Debug.Log("GOt Seen");
									gameObject.GetComponent<StrikeScript>().strikes--;
									bulletTran.gameObject.GetComponent<BulletBehavior>().justShot = false;
								}

								_oneShot = true;
							}
						}
						else
						{
							colliders.Clear();
						}
					}
				}
			}

		}

	}


private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, GirlGazeRadius);
	}


	public Vector3 FindCurrentAngle(float gazeAngle,bool isAngleGlobal)
	{
		if (!isAngleGlobal)
		{
			gazeAngle += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(gazeAngle*Mathf.Deg2Rad),0,Mathf.Cos(gazeAngle*Mathf.Deg2Rad));
	}
}




