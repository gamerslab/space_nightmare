using UnityEngine;
using System.Collections;

public class CarChangeColor : MonoBehaviour {
	public float redComponent;
	public float greenComponent;
	public float blueComponent;
	// Use this for initialization
	void Start () {
		Color currentColor = renderer.materials[1].color;
		currentColor.r = redComponent;
		currentColor.g = greenComponent;
		currentColor.b = blueComponent;
		
		renderer.materials[0].SetColor ("_Color", currentColor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
