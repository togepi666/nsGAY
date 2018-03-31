using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
	public int CurrentMaterialIndex = 0;
	public Renderer MainScreen, Screen2, Screen3;
	public Material[] RenderTextureMaterial = new Material[3];
	private AudioSource _changeSound;

	private void Start()
	{
		_changeSound = MainScreen.gameObject.GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetKeyDown(",") || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			CurrentMaterialIndex--;
			_changeSound.PlayOneShot(_changeSound.clip);
		}

		if (Input.GetKeyDown(".") || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			CurrentMaterialIndex++;
			_changeSound.PlayOneShot(_changeSound.clip);
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
