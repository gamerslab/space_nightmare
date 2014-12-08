using UnityEngine;
using System.Collections;

public class ScreenTilting2 : MonoBehaviour {
	float accumulator = 0.0f;
	Renderer screenShader;
	
	// Use this for initialization
	void Start () {
		screenShader = transform.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (accumulator <= 0.0f)
		{
			int randomNumber = Random.Range (0, 3);
			if (randomNumber == 0)
			{
				Color currentColor = screenShader.materials[1].color;
				currentColor.r = 1f-currentColor.r;
				currentColor.g = 1f-currentColor.g;
				currentColor.b = 1f-currentColor.b;

				screenShader.materials[1].SetColor ("_Color", currentColor);
			}
			
			accumulator = 0.2f;
		}
		else
		{
			accumulator-=Time.deltaTime;
		}
	}
}
