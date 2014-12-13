using UnityEngine;
using System.Collections;

public class LadderClimber : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.gameObject.SendMessage("ladderScaling");
		} else {
			Debug.Log ("Alien detected from ladder");
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			other.gameObject.SendMessage("ladderLeaving");
		} else {
			Debug.Log ("Alien detected from ladder");
		}
	}
	
}
