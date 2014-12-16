using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {
	public string levelName;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			LoadManager.LoadLevel(levelName);
			Destroy(gameObject);
		}
	}
}
