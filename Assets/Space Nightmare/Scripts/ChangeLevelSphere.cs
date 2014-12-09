using UnityEngine;
using System.Collections;

public class ChangeLevelSphere : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player detected");
			Application.LoadLevel("level_space");
		} else {
			Debug.Log ("Alien detected");
		}
	}
}
