using UnityEngine;
using System.Collections;

public class SpiderClimber : MonoBehaviour {
	bool top = false;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			Debug.Log (other.name+" detected from ladder");
			other.gameObject.SendMessage("wallScaling");
		} else {
			Debug.Log ("Alien detected from ladder");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Enemy") {
			other.gameObject.SendMessage("wallLeaving");
			Debug.Log (other.name+" detected from ladder");
		} else {
			Debug.Log ("Alien2 detected from ladder");
		}
	}
}
