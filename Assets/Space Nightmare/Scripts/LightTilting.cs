using UnityEngine;
using System.Collections;

public class LightTilting : MonoBehaviour {
	Light currentLight;
	float accumulator = 0.0f;
	// Use this for initialization
	void Start () {
		currentLight = transform.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (accumulator <= 0.0f)
		{
			int randomNumber = Random.Range (0, 3);
			if (randomNumber == 0)
			{
				float currentIntensity = currentLight.intensity;

				currentLight.intensity = 1f - currentIntensity;
			}
			
			accumulator = 0.2f;
		}
		else
		{
			accumulator-=Time.deltaTime;
		}
	}
}
