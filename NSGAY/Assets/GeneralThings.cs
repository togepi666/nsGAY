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

	public float currentTime;
	void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > 3){
			int ran = (int)(Random.RandomRange(0, 3)+1);

			SpawnEnemy(ran);
			currentTime = 0;
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
