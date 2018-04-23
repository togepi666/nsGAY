using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralThings : MonoBehaviour {

	// Use this for initialization
	public GameObject enemies;

	public GameObject mainCharacter;
	public GameObject spawnArea1;
	public GameObject spawnArea2;
	public GameObject spawnArea3;
	public GameObject timer;
	public float score = 0;
    public float difficulty = .02f;
	public float currentTime;

	private void Start()
	{
		GameObject[] importants = GameObject.FindGameObjectsWithTag("Important");
		{
			if (importants.Length > 1)
			{
				Destroy(gameObject);
			}
		}
	}

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	void Update()
	{
		if(spawnArea1.gameObject != null){
			currentTime += Time.deltaTime;
			if (currentTime > 3 + difficulty){
				int ran = (int)(Random.RandomRange(0, 3)+1);

				SpawnEnemy(ran);
				currentTime = 0 + difficulty;
			}

			if (timer.GetComponent<Timer>().timer > 10)
			{
				if (difficulty < 2)
				{
					difficulty += .4f;
				}
			}
		}
		if (timer != null)
		{
			score = timer.GetComponent<Timer>().timer;
		}

	}


	public void SpawnEnemy(int ran)
	{
		
		switch (ran)
		{
			case 1: Instantiate(enemies,spawnArea1.transform.position,Quaternion.identity,null);
				break;
			case 2: Instantiate(enemies,spawnArea2.transform.position,Quaternion.identity,null);
				break;
			case 3: Instantiate(enemies,spawnArea3.transform.position,Quaternion.identity,null);
				break;

		}
	}
}
