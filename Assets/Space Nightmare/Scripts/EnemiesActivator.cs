using UnityEngine;
using System.Collections;

public class EnemiesActivator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player detected");
			for(int i = 0; i < transform.childCount; i++) { //See all child and see they child
				if (transform.GetChild(i).tag == "Enemy") { //check tag of child
					transform.GetChild(i).SendMessage("Activate");
				}
			}
			for(int i = 0; i < transform.childCount; i++) { //See all child and see they child
				if (transform.GetChild(i).tag == "EnemyFactoryObject") { //check tag of child
					transform.GetChild(i).SendMessage("Activate");
				}
			}
		} else {
			Debug.Log ("Alien detected");
		}
	}
}
