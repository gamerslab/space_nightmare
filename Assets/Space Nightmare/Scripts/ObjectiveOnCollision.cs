using UnityEngine;
using System.Collections;

public class ObjectiveOnCollision : MonoBehaviour {
	public string newObjective;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			ObjectiveManager.Instance.NewObjective(newObjective);
			Destroy(gameObject);
		}
	}
}
