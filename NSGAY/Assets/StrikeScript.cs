using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeScript : MonoBehaviour {
    public int strikes = 3;
    public bool gameOver = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (strikes <= 0)
        {
            gameOver = true;
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            strikes--;
        }
    }

}
