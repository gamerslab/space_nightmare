using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class TextTilting : MonoBehaviour {
	Text text;
	float accumulator = 0.0f;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (accumulator <= 0.0f) {
			if (Random.Range(0, 3) == 0) {
				Color currentColor = text.color;
				currentColor.r = 1f-currentColor.r;
				currentColor.g = 1f-currentColor.g;
				currentColor.b = 1f-currentColor.b;
				
				text.color = currentColor;
			}
			
			accumulator = 0.2f;
		} else {
			accumulator-=Time.deltaTime;
		}
	}
}
