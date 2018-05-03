using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrikeScript : MonoBehaviour {
    public int strikes = 3;
    public bool gameOver = false;
    public bool GirlHit;
    public GameObject strike1, strike2;


    private CameraSwitching _switch;
    private Animator _animControl;
    private LineOfSightCollider _liney;

	// Use this for initialization
	void Start ()
	{
	    _switch = GameObject.FindGameObjectWithTag("CameraController").GetComponent<CameraSwitching>();
	    _liney = GetComponentInChildren<LineOfSightCollider>();
	    _animControl = GetComponent<Animator>();
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
            SceneManager.LoadScene(2);
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<EnemyBehavior>().alive)
            {
                GirlHit = true;
                strikes--;
                other.gameObject.GetComponent<EnemyBehavior>().alive = false;

            }
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            if (!other.gameObject.GetComponent<BulletBehavior>().crashed && !_liney.StrikeOnce)
            {
                transform.LookAt(GetComponent<girlGaze>().CameraTransform[_switch.CurrentMaterialIndex].position);
                _animControl.SetBool("hitByBullet", true);
                GirlHit = true;
                strikes--;
                other.gameObject.GetComponent<BulletBehavior>().crashed = true;
                other.gameObject.GetComponent<BulletBehavior>().justShot = false;
                Debug.Log("SET TO TRUE");
            }

            if (!other.gameObject.GetComponent<BulletBehavior>().crashed && _liney.StrikeOnce)
            {
                GirlHit = false;
                other.gameObject.GetComponent<BulletBehavior>().crashed = true;
                other.gameObject.GetComponent<BulletBehavior>().justShot = false;
                Debug.Log("NO DOUBLES HERE");
            }
        }
    }

}
