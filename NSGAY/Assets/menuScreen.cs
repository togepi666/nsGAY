using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuScreen : MonoBehaviour {

    public Button b;

	// Use this for initialization
	void Start () {
        b.onClick.AddListener(startGame);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void startGame()
    {
        Debug.Log("Clicked button");
        SceneManager.LoadScene(0);
    }
}
