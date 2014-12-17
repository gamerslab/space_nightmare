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
		LoadManager.LoadLevel ("level_menu");
	}

	void TimeOut() {
		DialogManager.Add (
			new DialogManager.Callback (LoadTitle),
			@"When the bomb exploded, a
chain of reactions in the
reactor room destabilized the
wormhole that had been opened.",

@"However, in order to prevent
such a disaster to happen again,
the Global Government created
an special elite force to
investigate space-time anomalies.",

@"June, 2035:

Origin: Titan, moon of Jupiter
Sender: Icarus, scientific team
		studying its geography
Message: We are meeting the
schedule. Supplies are
guaranteed.",

@"       However, Johann
went to investigate a strange
light phenomena and is still
missing. We are preparing an
expedition to look for him.",

@"THE WAR FOR OUR SOLAR
SYSTEM...| HAS JUST BEGUN."
		);
	}
}
