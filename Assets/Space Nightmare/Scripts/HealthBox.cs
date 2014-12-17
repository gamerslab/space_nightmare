using UnityEngine;
using System.Collections;

public class HealthBox : MonoBehaviour {
	public AudioClip healthAudio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.SendMessage("HealthRecharge", 20);
			AudioSource.PlayClipAtPoint(healthAudio, Camera.main.transform.position);
			Destroy(gameObject);
		}
	}
}
