using UnityEngine;
using System.Collections;

public class ScreenShutdown : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Renderer screenShader = transform.GetComponent<Renderer>();
		Color currentColor = screenShader.materials[1].color;
		currentColor.r = 0f;
		currentColor.g = 0f;
		currentColor.b = 0f;

		screenShader.materials[1].SetColor ("_Color", currentColor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
