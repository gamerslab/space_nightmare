using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	public GameObject enemy;
	public Transform target;
	public float likelihood;
	float accumulator = 0.0f;
	public bool isActive;
	int taken;
	// Use this for initialization
	void Start () {
		taken = (int) Mathf.Floor (likelihood * 100);
	}
	
	// Update is called once per frame
	void Update () {
		if (isActive) {
			if (accumulator >= 1.0f) {
				int randomNumber = Random.Range (0, 100);
				if (randomNumber < taken) {
					GameObject currentEnemy = (GameObject)Instantiate (enemy, transform.position, transform.rotation); 
					currentEnemy.SendMessage ("SetTarget", target);
				}
				accumulator = 0.0f;
			} else {
				accumulator += Time.deltaTime;
			}
		}
	}

	void Activate()
	{
		isActive = true;
	}
}
