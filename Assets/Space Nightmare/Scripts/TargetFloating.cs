using UnityEngine;
using System.Collections;

public class TargetFloating : MonoBehaviour {
	float initialY;
	public float spinningAngle = 1.0f;
	bool ascending = true;
	public float initialSpeed = 0.01f;
	public float deceleration = 0.0002f;
	float currentSpeed;
	public Transform targetObject;

	// Use this for initialization
	void Start () {
		currentSpeed = initialSpeed;
		initialY = targetObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		targetObject.transform.Rotate(0.0f,spinningAngle,0.0f);
		Debug.Log (currentSpeed+" "+ascending);
		if (ascending) 
		{
			if (targetObject.transform.position.y >= initialY)
			{
				targetObject.transform.Translate(0.0f,currentSpeed,0.0f);
				currentSpeed -= deceleration;
			}
			else
			{
				targetObject.transform.Translate(0.0f,initialY-targetObject.transform.position.y,0.0f);
				currentSpeed = -initialSpeed;
				ascending = false;
			}
		} 
		else 
		{
			if (targetObject.transform.position.y <= initialY)
			{
				targetObject.transform.Translate(0.0f,currentSpeed,0.0f);
				currentSpeed += deceleration;
			}
			else
			{
				targetObject.transform.Translate(0.0f,initialY-targetObject.transform.position.y,0.0f);
				currentSpeed = initialSpeed;
				ascending = true;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.SendMessage("TargetReached");
			Destroy(targetObject.gameObject);
			Destroy(gameObject);
		}
	}
}
