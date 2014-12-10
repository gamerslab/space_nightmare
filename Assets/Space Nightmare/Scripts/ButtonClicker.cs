using UnityEngine;
using System.Collections;

public class ButtonClicker : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseClick()
	{
		Application.LoadLevel("level_hangar");
	}
}
