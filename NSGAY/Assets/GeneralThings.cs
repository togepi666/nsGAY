using UnityEngine;
using Random = System.Random;

public class GeneralThings : MonoBehaviour
{

	public GameObject enemies;

	public GameObject mainCharacter;
	public GameObject spawnArea1;
	public GameObject spawnArea2;
	public GameObject spawnArea3;
	
	
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
}
