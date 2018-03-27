using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{

	public int CurrentWebCamIndex = 0;
	public Camera Camera1, Camera2, Camera3;

	public RenderTexture WebcamRenderer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(","))
		{
			CurrentWebCamIndex--;
		}

		if (Input.GetKeyDown("."))
		{
			CurrentWebCamIndex++;
		}

		if (CurrentWebCamIndex <= -1)
		{
			CurrentWebCamIndex = 2;
		}

		if (CurrentWebCamIndex >= 3)
		{
			CurrentWebCamIndex = 0;
		}
		switch (CurrentWebCamIndex)
		{
				default:
					Camera1.targetTexture = WebcamRenderer;
					Camera2.targetTexture = null;
					Camera3.targetTexture = null;
					break;
				case 1:
					Camera1.targetTexture = null;
					Camera2.targetTexture = WebcamRenderer;
					Camera3.targetTexture = null;
					break;
				case 2:
					Camera1.targetTexture = null;
					Camera2.targetTexture = null;
					Camera3.targetTexture = WebcamRenderer;
					break;
		}
	}
}
