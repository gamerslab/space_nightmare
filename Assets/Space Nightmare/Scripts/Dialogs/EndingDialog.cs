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
			@"THE END"
		);
	}
}
