using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Graphs;
using UnityEngine;

public class girlGaze : MonoBehaviour
{
	public float GirlFOV = 110f;
	public float GirlGazeRadius;
	[Range(0,360)]
	public float GirlGazeAngle;
	public LayerMask[] deviceLayerMask = new LayerMask[3];
	public LayerMask CameraMasks;
	public List<Transform> VisibilityList = new List<Transform>();
	public Transform[] CameraTransform = new Transform[3];


	private CameraSwitching _camSwitch;
	private float _currentRayAngle;
	private GameObject _camController;
	private Vector3 _gazeDirection;
	private void Start()
	{
		_camController = GameObject.FindGameObjectWithTag("CameraController");
		_camSwitch = _camController.GetComponent<CameraSwitching>();
		//StartCoroutine(FindTarget());
	}

	void FixedUpdate()
	{
		DetectCamera();
	}
	/*IEnumerator FindTarget()
	{
		yield return  new WaitForSeconds(0.2f);
		DetectCamera();
	}*/
	private void DetectCamera()
	{
		//VisibilityList.Clear();
		Collider[] visbleCameras =
			Physics.OverlapSphere(transform.position, GirlGazeRadius, CameraMasks);
		for (int i = 0; i < visbleCameras.Length; i++)
		{
			Transform cameraPos = visbleCameras[i].transform;
			_gazeDirection = (cameraPos.position - transform.position).normalized;
			if (Vector3.Angle(transform.forward, _gazeDirection) < GirlGazeAngle / 2)
			{
				float rayDistance = Vector3.Distance(transform.position, cameraPos.position);
				if (Physics.Raycast(transform.position, _gazeDirection, rayDistance, CameraMasks))
				{
					VisibilityList.Add(cameraPos);
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
		Handles.color = Color.blue;
		foreach (var camera in gazer.VisibilityList)
		{
			Handles.DrawLine(gazer.transform.position,camera.position);
		}
	}
}
