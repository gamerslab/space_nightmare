using UnityEngine;
using System.Collections;

public class SpiderFactory : MonoBehaviour {
	public GameObject spider;
	public Transform target;
	public float likelihood;
	float accumulator = 0.0f;
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
								GameObject currentSpider = (GameObject)Instantiate (spider, transform.position, transform.rotation); 
								currentSpider.SendMessage ("SetTarget", target);
						}
			accumulator = 0.0f;
				} else {
						accumulator += Time.deltaTime;
				}
	}
}
