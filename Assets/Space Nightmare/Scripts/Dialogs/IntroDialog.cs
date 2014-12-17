using UnityEngine;
using System.Collections;

public class IntroDialog : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
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
communications are lost.",

@"Unidentified creatures
started to appear in the
Earth surface.|

The space station was
acting as a link between
the wormhole and the Earth.",

			@"August, 2034:

I was assigned to destroy the
space station, Cluster.|

Just when I was about to
leave... The hangar was
attacked..."
		);
	}
}
