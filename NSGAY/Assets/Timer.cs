using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public float timer;


	// Use this for initialization
	void Start () {
        timer = 0;
	}

    private void Awake()
    {
    }

    // Update is called once per frame
    void Update () {
        if (GameObject.Find("Girl").GetComponent<StrikeScript>().strikes > 0)
        {
            timer += 1 * Time.deltaTime;
            GetComponent<Text>().text = timer.ToString("#.00");
        }
    }
}
