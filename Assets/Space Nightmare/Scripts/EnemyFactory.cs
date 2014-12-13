using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {
	public GameObject enemy;
	public Transform target;
	public float likelihood;
	public ParticleSystem creationEffects;
	public float radium;
	float accumulator = 0.0f;
	float effectAccumulator = 0.0f;
	float timeOfEffect = 0.3f;
	float totalAccumulator = 0.0f;
	public float timeOfLife;
	float distance;
	int degrees;
	int taken;
	bool effectsPlaying = false;
	// Use this for initialization
	void Start () {
		taken = (int) Mathf.Floor (likelihood * 100);
	}
	
	// Update is called once per frame
	void Update () {
		if (accumulator >= 1.0f) {
			int randomNumber = Random.Range (0, 100);
			if (randomNumber < taken) {
				degrees = Random.Range(0,359);
				distance = Random.Range(0,radium);

				gameObject.transform.Translate(distance*Mathf.Sin(degrees),0.0f,distance*Mathf.Cos(degrees));
				GameObject currentEnemy = 
					(GameObject)Instantiate (enemy, transform.position, transform.rotation); 
				currentEnemy.SendMessage ("SetTarget", target);
				effectAccumulator = 0.0f;
				creationEffects.Play();
				effectsPlaying = true;
			}
			accumulator = 0.0f;
		} else {
			accumulator += Time.deltaTime;
		}
		if (effectAccumulator >= timeOfEffect && effectsPlaying) 
		{
			effectsPlaying = false;
			creationEffects.Stop();
//			gameObject.transform.Translate(-distance*Mathf.Sin(degrees),0.0f,-distance*Mathf.Cos(degrees));
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
