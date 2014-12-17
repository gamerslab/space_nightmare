using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.lockCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame() {
		LoadManager.LoadLevel ("level_intro");
	}

	public void Exit() {
		Application.Quit ();
	}
}
