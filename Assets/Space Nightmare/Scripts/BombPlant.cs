using UnityEngine;
using System.Collections;

public class BombPlant : MonoBehaviour {
	public GameObject escapeEnemies;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			ObjectiveManager.Instance.NewObjective("Return to your spaceship!!!");

			// Enable escape enemies
			escapeEnemies.SetActive(true);

			Destroy(gameObject);
		}
	}
}
