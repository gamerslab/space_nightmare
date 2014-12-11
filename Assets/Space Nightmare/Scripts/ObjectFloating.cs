using UnityEngine;
using System.Collections;

public class ObjectFloating : MonoBehaviour {
	float initialY;
	public float spinningAngle = 1.0f;
	bool ascending = true;
	public float initialSpeed = 0.01f;
	public float deceleration = 0.0002f;
	float currentSpeed;

	// Use this for initialization
	void Start () {
		currentSpeed = initialSpeed;
		initialY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0.0f,spinningAngle,0.0f);
		if (ascending) 
		{
			if (transform.position.y >= initialY)
			{
				transform.Translate(0.0f,currentSpeed,0.0f);
				currentSpeed -= deceleration;
			}
			else
			{
				transform.Translate(0.0f,initialY-transform.position.y,0.0f);
				currentSpeed = -initialSpeed;
				ascending = false;
			}
		} 
		else 
		{
			if (transform.position.y <= initialY)
			{
				transform.Translate(0.0f,currentSpeed,0.0f);
				currentSpeed += deceleration;
			}
			else
			{
				transform.Translate(0.0f,initialY-transform.position.y,0.0f);
				currentSpeed = initialSpeed;
				ascending = true;
			}
		}
	}
}
