using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {
	bool isOpening = false;
	bool isOpened = false;
	Transform door;
	public float doorSlide;
	public int typeKey;

	// Use this for initialization
	void Start () {
		door = transform.Find ("Door");
		Transform door2 = door.Find ("Plane");
		Renderer doorShader1 = door.GetComponent<Renderer>();
		Color currentColor = doorShader1.materials[0].color;
		currentColor.r = 0f;
		currentColor.g = 0f;
		currentColor.b = 0f;
		
		Renderer doorShader2 = door2.GetComponent<Renderer>();
		if (typeKey == 0) 
		{
			currentColor.r = 1f;
			doorShader1.materials[0].SetColor ("_Color", currentColor);
			doorShader2.materials[0].SetColor ("_Color", currentColor);
		} else if (typeKey == 1) 
		{
			currentColor.g = 1f;
			doorShader1.materials[0].SetColor ("_Color", currentColor);
			doorShader2.materials[0].SetColor ("_Color", currentColor);
		} 
		else 
		{
			currentColor.b = 1f;
			doorShader1.materials[0].SetColor ("_Color", currentColor);
			doorShader2.materials[0].SetColor ("_Color", currentColor);
		}
		GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isOpened) {
			if (isOpening) {
				doorSlide -= Time.deltaTime;
				door.transform.Translate (Time.deltaTime, 0.0f, 0.0f);
			}
			if (doorSlide <= 0.0f) {
				isOpened = true;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!isOpening) {
			if (other.tag == "Player") {
				Debug.Log ("Player detected");
				if ((other.gameObject.GetComponent<FirstPersonController> ()).hasKey (typeKey)) {
					other.SendMessage("wasteKey",typeKey);
					Debug.Log ("Nice key");
					isOpening = true;
				} else {
					Debug.Log ("No key");
				}
			} else {
				Debug.Log ("Alien detected");
			}
		}
	}
}
