using UnityEngine;
using System.Collections;

public class ObjectiveOnCollision : MonoBehaviour {
	public string newObjective;
	public GameObject nextTargetActivator;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			ObjectiveManager.Instance.NewObjective(newObjective);
			nextTargetActivator.SetActive(true);
			Destroy (gameObject);
		}
	}
}
