using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class girlGaze : MonoBehaviour
{
	public float GirlGazeRadius;
	[Range(0,360)]
	public float GirlGazeAngle;

	public LayerMask BulletLayerMask;
	public LayerMask[] DeviceLayerMask = new LayerMask[3];
	public Transform[] CameraTransform = new Transform[3];


	private bool _oneShot;
	private float _currentRayAngle;
	private GameObject _camController;
	private List<Transform> _bulletTransforms;
	private void Start()
	{
		//StartCoroutine(FindTarget());
	}

	void Update()
	{
		
	}

	private void FixedUpdate()
	{
		DetectCamera();
	}

	private void DetectCamera()
	{
		//VisibilityList.Clear();

		for (int i = 0; i < DeviceLayerMask.Length; i++)
		{
			Physics.OverlapSphere(transform.position, GirlGazeRadius,DeviceLayerMask[i] );
			Vector3 _gazeDirection = (CameraTransform[i].position - transform.position).normalized;
			if (Vector3.Angle( _gazeDirection,transform.forward) <= GirlGazeAngle / 2)
			{
				float rayDistance = Vector3.Distance(transform.position, CameraTransform[i].position);
				if (Physics.Raycast(transform.position, _gazeDirection, rayDistance,DeviceLayerMask[i] ))
				{
					Debug.DrawLine(transform.position,CameraTransform[i].position,Color.blue);
					RaycastHit bulletHit;
					List<Collider> colliders = new List<Collider>();
					colliders.AddRange(Physics.OverlapSphere(transform.position, GirlGazeRadius, BulletLayerMask));
					//Collider[] bulletColliders = Physics.OverlapSphere(transform.position, GirlGazeRadius, BulletLayerMask);
					for (int j = 0; j < colliders.Count; j++)
					{
						var bulletTran = colliders[j].gameObject.transform;
						Vector3 bulletRayDirection = (bulletTran.position - transform.position).normalized;
						float bulletRayDist = Vector3.Distance(transform.position, bulletTran.position);
						if (Physics.Raycast(transform.position, bulletRayDirection, bulletRayDist, BulletLayerMask))
						{
							_oneShot = false;
							Debug.DrawLine(bulletTran.position,transform.position,Color.yellow);
							if (!_oneShot)
							{
								if (bulletTran.gameObject.GetComponent<BulletBehavior>().justShot == true)
								{
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
		
			/*else
			{
				_camSwitch.DeviceTriggered[_camSwitch.CurrentMaterialIndex] = false;
			}*/
		}


		/*if (Physics.Raycast(girlRay, out compOnHit,rayDist, compCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 0)
			{
				_camSwitch.CompTriggered = true;
			}
		}
		if (!Physics.Raycast(girlRay, out compOnHit,rayDist, compCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 0)
			{
				_camSwitch.CompTriggered = false;
			}
		}
		if (Physics.Raycast(girlRay, out phoneOnHit,rayDist, phoneCamLayerMask))
		{
	
			if (_camSwitch.CurrentMaterialIndex == 1)
			{
				_camSwitch.PhoneTriggered = true;
			}
		}
		if (!Physics.Raycast(girlRay, out phoneOnHit,rayDist, phoneCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 1)
			{
				_camSwitch.PhoneTriggered = false;
			}
		}
		if (Physics.Raycast(girlRay, out echoOnHit,rayDist, echoCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 2)
			{
				_camSwitch.EchoTriggered = true;
			}
		}
		if (!Physics.Raycast(girlRay, out echoOnHit,rayDist, echoCamLayerMask))
		{
			if (_camSwitch.CurrentMaterialIndex == 2)
			{
				_camSwitch.EchoTriggered = false;
			}
		}*/
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
/*
[CustomEditor(typeof(girlGaze))]
public class drawSight : Editor
{
	private GameObject _camObj;
	private CameraSwitching _cam;

	private void OnEnable()
	{
		_camObj = GameObject.FindGameObjectWithTag("CameraController");
		_cam = _camObj.GetComponent<CameraSwitching>();
	}
	private void OnSceneGUI()
	{
		Handles.color = Color.magenta;
		girlGaze gazer = (girlGaze) target;
		Handles.DrawWireArc(gazer.transform.position,Vector3.up,Vector3.forward, 360,gazer.GirlGazeRadius);
		Vector3 viewLineA = gazer.FindCurrentAngle(-gazer.GirlGazeAngle / 2,false);
		Vector3 viewLineB = gazer.FindCurrentAngle(gazer.GirlGazeAngle / 2,false);
		Handles.DrawLine(gazer.transform.position,gazer.transform.position+viewLineA *gazer.GirlGazeRadius);
		Handles.DrawLine(gazer.transform.position,gazer.transform.position+viewLineB *gazer.GirlGazeRadius);
	}
}
*/
