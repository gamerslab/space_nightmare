using UnityEngine;
using System.Collections;

public class AmmoBox : MonoBehaviour {
	public AudioClip ammoAudio;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.SendMessage("AmmoRecharge",120);
			AudioSource.PlayClipAtPoint(ammoAudio, Camera.main.transform.position);
			Destroy(gameObject);
		}
	}
}
