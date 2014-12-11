using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	public GameObject enemy;
	public Transform target;
	public float likelihood;
	public ParticleSystem creationEffects;
	float accumulator = 0.0f;
	float effectAccumulator = 0.0f;
	float timeOfEffect = 0.3f;
	float totalAccumulator = 0.0f;
	public float timeOfLife;
	int taken;
	// Use this for initialization
	void Start () {
		taken = (int) Mathf.Floor (likelihood * 100);
	}
	
	// Update is called once per frame
	void Update () {
		if (accumulator >= 1.0f) {
			int randomNumber = Random.Range (0, 100);
			if (randomNumber < taken) {
				GameObject currentEnemy = (GameObject)Instantiate (enemy, transform.position, transform.rotation); 
				currentEnemy.SendMessage ("SetTarget", target);
				effectAccumulator = 0.0f;
				creationEffects.Play();
			}
			accumulator = 0.0f;
		} else {
			accumulator += Time.deltaTime;
		}
		if (effectAccumulator >= timeOfEffect) 
		{
			creationEffects.Stop();
		} 
		else 
		{
			effectAccumulator += Time.deltaTime;
		}
		totalAccumulator += Time.deltaTime;
		if (totalAccumulator >= timeOfLife) 
		{
			Destroy(gameObject);
		}
	}
}
