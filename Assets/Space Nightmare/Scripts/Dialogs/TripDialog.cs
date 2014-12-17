using UnityEngine;
using System.Collections;

public class TripDialog : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadSpace() {
		LoadManager.LoadLevel ("level_space");
	}
	
	void TimeOut() {
		DialogManager.Add (
			new DialogManager.Callback (LoadSpace),
@"4 hours later:

I can see the space station.
I need to find the reactor room
and plant the bomb there.|

The security is high. Some
doors are locked. I'll need to
get the right magnetic cards in
order to reach the main reactor.",

@"I'll set the bomb timer to 2
minutes. I better have a clear
escape route, I don't want to
get caught in the explosion..."
		);
	}
}
