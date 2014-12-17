using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	public GameObject hud;
	bool shown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Toggle() {
		shown = !shown;
		gameObject.SetActive (shown);
		hud.SetActive (!shown);
		Screen.lockCursor = !shown;
	}

	public void Continue() {
		Toggle ();
		LoadManager.LoadLevel (Application.loadedLevelName);
	}

	public void Exit() {
		Toggle ();
		LoadManager.LoadLevel ("level_menu");
	}
}
