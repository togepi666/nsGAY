using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitching : MonoBehaviour
{
	public int CurrentMaterialIndex = 0;
	public Camera DeskCamera, PhoneCamera, EchoCamera;
	private AudioSource _changeSound;
	private Rect _mainScreen = new Rect(0,0,0.65f,1);
	private Rect _screen2 = new Rect(0.65f,0.5f,0.35f,0.5f);
	private Rect _screen3 = new Rect(0.65f,0,0.35f,0.5f);

	private void Start()
	{
		_changeSound = GetComponent<AudioSource>();
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
				DeskCamera.depth = -1;
				PhoneCamera.depth = 0;
				EchoCamera.depth = 0;
				DeskCamera.rect = _mainScreen;
				PhoneCamera.rect = _screen2;
				EchoCamera.rect = _screen3;
				break;
			case 1:
				DeskCamera.depth = 0;
				PhoneCamera.depth = -1;
				EchoCamera.depth = 0;
				DeskCamera.rect = _screen2;
				PhoneCamera.rect = _mainScreen;
				EchoCamera.rect = _screen3;
				break;
			case 2:
				DeskCamera.depth = 0;
				PhoneCamera.depth = 0;
				EchoCamera.depth = -1;
				DeskCamera.rect = _screen3;
				PhoneCamera.rect = _screen2;
				EchoCamera.rect = _mainScreen;
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
