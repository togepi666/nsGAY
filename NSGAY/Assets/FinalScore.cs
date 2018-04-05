using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {
    float score;

	private GameObject generalStuff;
	// Use this for initialization
	void Start () {
		generalStuff= GameObject.FindGameObjectWithTag("Important");
		score = generalStuff.GetComponent<GeneralThings>().score;
	}
	
	// Update is called once per frame
	void Update () {
		
       // score = GameObject.Find("timer").GetComponent<Timer>().timer;
        GetComponent<Text>().text = "Time " + score;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene(0);
			Destroy(generalStuff.gameObject);

		}
	}
}
