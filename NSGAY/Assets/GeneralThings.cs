<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralThings : MonoBehaviour {
=======
﻿using UnityEngine;
using Random = System.Random;

public class GeneralThings : MonoBehaviour
{

>>>>>>> f41f7591362c31b93b23adba88c9e6df79aba7d1
	public GameObject enemies;

	public GameObject mainCharacter;
	public GameObject spawnArea1;
	public GameObject spawnArea2;
	public GameObject spawnArea3;
<<<<<<< HEAD

	public float currentTime;
    
	// Use this for initialization
	void Start () {
        
	}
    
	// Update is called once per frame
	void Update()
	{
		currentTime += Time.deltaTime;
		if (currentTime > 3){
			int ran = (int)(Random.RandomRange(0, 3)+1);

			SpawnEnemy(ran);
			currentTime = 0;
		}
	}

	public void SpawnEnemy( int ran )
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

=======
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnEnemy()
	{
		int ran = (int)(UnityEngine.Random.RandomRange(0, 3)+1);
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
>>>>>>> f41f7591362c31b93b23adba88c9e6df79aba7d1
}
