using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	public GameObject pauseLayer;
	public GameObject hud;
	bool shown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Cancel")) {
			Toggle();
		}
	}

	public void Toggle() {
		shown = !shown;
		Time.timeScale = shown ? 0 : 1;
		pauseLayer.SetActive(shown);
		hud.SetActive (!shown);
		Screen.lockCursor = !shown;
	}

	public void Exit() {
		Toggle ();
		LoadManager.LoadLevel("level_menu");
	}
}
