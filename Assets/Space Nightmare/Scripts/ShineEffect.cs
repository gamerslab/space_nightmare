using UnityEngine;
using System.Collections;

public class ShineEffect : MonoBehaviour {
	public float frequency;

	Renderer renderer;
	float accum = 0;
	bool ascending = false;
	float interval;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		interval = 1f / frequency;
	}
	
	// Update is called once per frame
	void Update () {
		accum += Time.deltaTime;
		float value = accum / interval;

		if(value > 1f) {
			value = 0;
			accum = 0;
			ascending = !ascending;
		}

		if(ascending)
			value = 1 - value;

		Color color = new Color(value, value, value, renderer.materials[0].GetColor("_TintColor").a);

		renderer.materials [0].SetColor ("_TintColor", color);
	}
}
