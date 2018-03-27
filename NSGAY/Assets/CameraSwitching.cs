using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
	public int CurrentMaterialIndex = 0;
	public Renderer MainScreen, Screen2, Screen3;
	public Material[] RenderTextureMaterial = new Material[3];
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(","))
		{
			CurrentMaterialIndex--;
		}

		if (Input.GetKeyDown("."))
		{
			CurrentMaterialIndex++;
		}
		switch (CurrentMaterialIndex)
		{
			default:
				MainScreen.material = RenderTextureMaterial[0];
				Screen2.material = RenderTextureMaterial[1];
				Screen3.material = RenderTextureMaterial[2];
				break;
			case 1:
				MainScreen.material = RenderTextureMaterial[1];
				Screen2.material = RenderTextureMaterial[2];
				Screen3.material = RenderTextureMaterial[0];
				break;
			case 2:
				MainScreen.material = RenderTextureMaterial[2];
				Screen2.material = RenderTextureMaterial[0];
				Screen3.material = RenderTextureMaterial[1];
				break;
		}

		if (CurrentMaterialIndex <= -1)
		{
			CurrentMaterialIndex = 2;
		}

		if (CurrentMaterialIndex >= 3)
		{
			CurrentMaterialIndex = 0;
		}
	}
}
