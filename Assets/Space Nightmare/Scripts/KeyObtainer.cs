using UnityEngine;
using System.Collections;

public class KeyObtainer : MonoBehaviour {
	public int typeKey;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player detected");
			other.SendMessage("GiveKey", typeKey);
			Destroy(gameObject);
		} else {
			Debug.Log ("Alien detected");
		}
	}
}
