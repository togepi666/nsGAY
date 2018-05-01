using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralThings : MonoBehaviour {

	// Use this for initialization
	public GameObject enemies;
	public GameObject enemyType2;
	public GameObject mainCharacter;
	public GameObject spawnArea1;
	public GameObject spawnArea2;
	public GameObject spawnArea3;
	public GameObject timer;
	public GameObject explosion;
    public int score;
    public GameObject scoreKeeper;
    public float difficulty = .02f;
	public float currentTime;
	public float timer2 = 0;
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
		timer2 += Time.deltaTime;
		if(spawnArea1.gameObject != null){
			currentTime += Time.deltaTime;
			if (currentTime > 3){
				int ran = (int)(Random.RandomRange(0, 3)+1);
				int behavior = (int) Random.RandomRange(0, 3);
				if (behavior == 0)
				{
					SpawnEnemy1(ran, difficulty);
				}
				else
				{
					SpawnEnemy2(ran, difficulty, behavior);
				}
				currentTime = 0 + difficulty;
			}

			if (timer2 > 10)
			{
				timer2 = 0;
				if (difficulty <2.4)
				{
					difficulty += .05f;
				}
			}
		}
		if (timer != null)
		{
			score = scoreKeeper.GetComponent<ScoringScript>().score;
		}

	}

	//For direct enemies
	public void SpawnEnemy1(int ran, float diff)
	{
		
		switch (ran)
		{
			case 1: GameObject newEnemy= Instantiate(enemies,spawnArea1.transform.position,Quaternion.identity,null) as GameObject;
				newEnemy.GetComponent<EnemyBehavior>().speed += diff;
				//newEnemy.GetComponent<EnemyBehavior>().explosion = this.explosion;
				break;
			case 2: GameObject newEnemy2 =Instantiate(enemies,spawnArea2.transform.position,Quaternion.identity,null);
				newEnemy2.GetComponent<EnemyBehavior>().speed += diff;
			//	newEnemy2.GetComponent<EnemyBehavior>().explosion = this.explosion;

				break;
			case 3: GameObject newEnemy3 = Instantiate(enemies,spawnArea3.transform.position,Quaternion.identity,null);
				newEnemy3.GetComponent<EnemyBehavior>().speed += diff;
			//	newEnemy3.GetComponent<EnemyBehavior>().explosion = this.explosion;

				break;

		}
	}
	//For Squiggly enemies
	public void SpawnEnemy2(int ran, float diff, int behavior)
	{
		switch (ran)
		{
			case 1: GameObject newEnemy= Instantiate(enemyType2,spawnArea1.transform.position,Quaternion.identity,null) as GameObject;
				newEnemy.GetComponent<EnemyBehavior>().speed += diff;
				newEnemy.GetComponent<EnemyBehavior>().movementType = behavior;
			//	newEnemy.GetComponent<EnemyBehavior>().explosion = this.explosion;

				break;
			case 2: GameObject newEnemy2 =Instantiate(enemyType2,spawnArea2.transform.position,Quaternion.identity,null);
				newEnemy2.GetComponent<EnemyBehavior>().speed += diff;
				newEnemy2.GetComponent<EnemyBehavior>().movementType = behavior;
			//	newEnemy2.GetComponent<EnemyBehavior>().explosion = this.explosion;



				break;
			case 3: GameObject newEnemy3 = Instantiate(enemyType2,spawnArea3.transform.position,Quaternion.identity,null);
				newEnemy3.GetComponent<EnemyBehavior>().speed += diff;
				newEnemy3.GetComponent<EnemyBehavior>().movementType = behavior;
			//	newEnemy3.GetComponent<EnemyBehavior>().explosion = this.explosion;


				break;

		}
	}
}
