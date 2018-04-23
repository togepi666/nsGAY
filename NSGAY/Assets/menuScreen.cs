using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menuScreen : MonoBehaviour {

    public Button b;
    public Button c;
    public Button d;

    public GameObject iWindow;

	// Use this for initialization
	void Start () {
        b.onClick.AddListener(startGame);
        c.onClick.AddListener(instructions);
        d.onClick.AddListener(iExit);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void startGame()
    {
        Debug.Log("Clicked button");
        SceneManager.LoadScene(1);
    }

    public void instructions()
    {
        iWindow.SetActive(true);
    }

    public void iExit()
    {
        iWindow.SetActive(false);
    }
}
