using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {
	bool isOpening = false;
	bool isOpened = false;
	Transform door;
	public float doorSlide;
	public int typeKey;

	// Use this for initialization
	void Start () {
		door = transform.Find ("Door");
		GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpening) 
		{
			doorSlide -= Time.deltaTime;
			door.transform.Translate(Time.deltaTime,0.0f,0.0f);
		}
		if (doorSlide <= 0.0f) 
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!isOpening) {
			if (other.tag == "Player") {
				Debug.Log ("Player detected");
				if ((other.gameObject.GetComponent<FirstPersonController> ()).hasKey (typeKey)) {
					other.SendMessage("wasteKey",typeKey);
					Debug.Log ("Nice key");
					isOpening = true;
				} else {
					Debug.Log ("No key");
				}
			} else {
				Debug.Log ("Alien detected");
			}
		}
	}
}
