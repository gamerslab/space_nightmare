using UnityEngine;
using System.Collections;

public class IntroDialog : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void LoadHangar() {
		LoadManager.LoadLevel ("level_hangar");
	}

	void TimeOut() {
		DialogManager.Add (
			new DialogManager.Callback (LoadHangar),
			@"June, 2034:

NASA discovers a disturbance in
space-time located near Saturn.|

A thorough analysis of the data
concludes that someone was trying
to open a wormhole to the Solar
system.",
			@"July, 2034:

Cluster, a space station with
a team of 4 members, is
deployed near Saturn in order
to study the disturbance.|

After 6 days... All
communications are lost."
		);
	}
}
