using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScore : MonoBehaviour {
    float score;
    public Button b;

	private GameObject generalStuff;
	// Use this for initialization
	void Start () {
		generalStuff= GameObject.FindGameObjectWithTag("Important");
		score = generalStuff.GetComponent<GeneralThings>().score;
	}
	
	// Update is called once per frame
	void Update () {
        b.onClick.AddListener(startGame);
        // score = GameObject.Find("timer").GetComponent<Timer>().timer;
        // GetComponent<Text>().text = "Time: " + score.ToString("#.00");
        GetComponent<Text>().text = score + " Threats";

		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene(1);
			Destroy(generalStuff.gameObject);

		}
	}

    public void startGame()
    {
        Debug.Log("Clicked button");
        SceneManager.LoadScene(1);
    }
}
