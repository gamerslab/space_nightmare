using UnityEngine;
using System.Collections;

public class HeathBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player detected");
			other.SendMessage("HeathRecharge",20);
			Destroy(gameObject);
		} else {
			Debug.Log ("Alien detected");
		}
	}
}
