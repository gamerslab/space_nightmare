using UnityEngine;
using System.Collections;

public class IntroDialog : MonoBehaviour {
	public float delay = 1.0f;

	bool shown = false;
	float accum = 0;

	// Use this for initialization
	void Start () {

	}

	void LoadHangar() {
		LoadManager.LoadLevel ("level_hangar");
	}
	
	// Update is called once per frame
	void Update () {
		if(shown)
			return;

		accum += Time.deltaTime;

		if (accum >= delay) {
			shown = true;
			DialogManager.Add (
				new DialogManager.Callback (LoadHangar),
				@"June, 2034:

NASA discovers a disturbance in
space-time located near Saturn.|

A thorough analysis of the data
concluded that someone was trying
to open a wormhole to the Solar
system.",
				@"July, 2034:

Cluster, a space station with
a team of 4 members, was
deployed near Saturn in order
to study the disturbance.|

After 6 days... All
communications were lost.");
		}
	}
}
