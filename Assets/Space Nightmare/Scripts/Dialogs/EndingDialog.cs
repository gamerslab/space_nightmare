using UnityEngine;
using System.Collections;

public class EndingDialog : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void LoadTitle() {

	}

	void TimeOut() {
		DialogManager.Add (
			new DialogManager.Callback (LoadTitle),
			@"When the bomb exploded, it provoked
a chain of reactions in the reactor room,
which ended up destabilizing the
wormhole that had been opened.|

In the following hour after the 
detonation, the scientists confirmed
its collapse, and all the evil beings
that had crossed it were absorbed
back to their dimension.",
@"In the following weeks you were
praised for saving the Earth.|

However, in order to prevent such
a disaster to happen again, the 
Global Government ordered the creation
of an special elite force specialized
in fighting all kind of aliens.|
Because of your experience in this kind
of fights, you were given the command of this
unit.",
@"June, 2035:
The following message has been received:

Origin: Titan, moon of Jupiter
Sender: Icarus, scientific team
		studying its geography
Message: We are meeting the schedule,
the supplies are guaranteed. However,
Johan went to investigate a strange
light phenomena and is still missing.
We are preparing an expedition to 
look for him.",

@"THE WAR FOR OUR SOLAR SYSTEM
IS FAR FROM ENDING...|

AND YOUR DESTINY IS TO LEAD IT");
	}
}
