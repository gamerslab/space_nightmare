using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public float seconds;
	float accum = 0;
	bool done = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(accum >= seconds && !done) {
			SendMessage("TimeOut");
			done = true;
		} else {
			accum += Time.deltaTime;
		}
	}

	void TimeOut() {
		// Do nothing
	}
}
