using UnityEngine;
using System.Collections;

public class InitialGameScene : MonoBehaviour {
	float animationFirstDuration = 1.0f;
	float animationSecondDuration = 7.0f;
	float animationThirdDuration = 18.0f;
	float animationMoment = 0.0f;

	Vector3 finalSecondAnimationPosition;
	Vector3 frontShipPosition = new Vector3(1450.24f,7.27f,1426.88f);
	Vector3 finalSecondAnimationSpeed;
	float speed = -1.3f;
	// Use this for initialization
	void Start () {
		Debug.Log(transform.position.x+" "+transform.position.y+" "+transform.position.z);

		transform.GetComponent<CharacterController> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (animationMoment < animationFirstDuration) 
		{
			transform.Translate (Time.deltaTime*speed, 0.0f, 0.0f );
			animationMoment += Time.deltaTime;
		} 
		else if (animationMoment < animationSecondDuration)
		{
			transform.Rotate(0.0f,Time.deltaTime*3.0f,0.0f);
			animationMoment += Time.deltaTime;
			if (animationMoment > animationSecondDuration)
			{
				finalSecondAnimationPosition.x = frontShipPosition.x - transform.position.x;
				finalSecondAnimationPosition.y = frontShipPosition.y - transform.position.y;
				finalSecondAnimationPosition.z = frontShipPosition.z - transform.position.z;
				finalSecondAnimationSpeed.x = finalSecondAnimationPosition.x/(animationThirdDuration-animationSecondDuration);
				finalSecondAnimationSpeed.y = finalSecondAnimationPosition.y/(animationThirdDuration-animationSecondDuration);
				finalSecondAnimationSpeed.z = finalSecondAnimationPosition.z/(animationThirdDuration-animationSecondDuration);
				Debug.Log(transform.position.x+" "+transform.position.y+" "+transform.position.z);
				Debug.Log(finalSecondAnimationSpeed.x+" "+finalSecondAnimationSpeed.y+" "+finalSecondAnimationSpeed.z);
				Debug.Log(transform.position.x+" "+transform.position.y+" "+transform.position.z);
			}
		}
		else if (animationMoment < animationThirdDuration)
		{
			transform.Translate(Time.deltaTime*finalSecondAnimationSpeed.x,
			                 Time.deltaTime*finalSecondAnimationSpeed.y,
			                 Time.deltaTime*finalSecondAnimationSpeed.z);
			animationMoment += Time.deltaTime;
		}
		else 
		{
			transform.GetComponent<CharacterController> ().enabled = true;
		}
	}
}
