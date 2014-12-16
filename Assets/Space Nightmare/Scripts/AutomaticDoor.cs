using UnityEngine;
using System.Collections;

public class AutomaticDoor : MonoBehaviour {
	bool isOpening = false;
	Transform door;
	public float doorSlide;
	public float openingSpeed;
	float currentDisplacement = 0.0f;
	float initialX, finalX;
	
	// Use this for initialization
	void Start () {
		door = transform.Find ("Door");
		initialX = door.position.z;
		finalX = door.position.z + doorSlide;
		Debug.Log("init: "+initialX+" fin: "+finalX);
	}
	
	// Update is called once per frame
	void Update () {
		if (isOpening) 
		{
			if (currentDisplacement > doorSlide) 
			{
				currentDisplacement -= Time.deltaTime*openingSpeed;
				Debug.Log("init: "+initialX+" curr: "+(door.position.z-Time.deltaTime*openingSpeed)+
				          " diff: "+(initialX-door.position.z));
				if ((door.position.z-Time.deltaTime*openingSpeed) < finalX)
					door.transform.Translate (finalX-door.position.z, 0.0f, 0.0f);
				else
					door.transform.Translate (-Time.deltaTime*openingSpeed, 0.0f, 0.0f);
			}
		} 
		else 
		{
			if (currentDisplacement < 0.0f)
			{
				currentDisplacement += Time.deltaTime*openingSpeed;
				Debug.Log("init: "+initialX+" curr: "+door.position.z+" diff: "+(initialX-door.position.z));
				if ((door.position.z+Time.deltaTime*openingSpeed) > initialX)
					door.transform.Translate (initialX-door.position.z, 0.0f, 0.0f);
				else
					door.transform.Translate (Time.deltaTime*openingSpeed, 0.0f, 0.0f);
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			isOpening = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			isOpening = false;
		}
	}
}
