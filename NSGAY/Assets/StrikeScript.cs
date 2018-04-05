﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrikeScript : MonoBehaviour {
    public int strikes = 3;
    public bool gameOver = false;
    public GameObject strike1, strike2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (strikes <= 0)
        {
            gameOver = true;
        }

        if (strikes == 2)
        {
            strike1.SetActive(true);
        }

        if (strikes == 1)
        {
            strike2.SetActive(true);
        }
        if (strikes == 0)
        {
            SceneManager.LoadScene(1);
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(other.gameObject.GetComponent<EnemyBehavior>().alive)
            strikes--;
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            if (!other.gameObject.GetComponent<BulletBehavior>().crashed)
            {
                strikes--;
                other.gameObject.GetComponent<BulletBehavior>().crashed = true;
                Debug.Log("Strikes -1");

            }
        }
    }

}
