using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyObtainer : MonoBehaviour {
	public int typeKey;
	public RawImage keyUI;

	// Use this for initialization
	void Start () {
		Transform firstCube = transform.Find ("Cube1");
		Transform secondCube = transform.Find ("Cube2");
		Renderer screenShader1 = firstCube.GetComponent<Renderer>();
		Color currentColor = screenShader1.materials[0].color;
		currentColor.r = 0f;
		currentColor.g = 0f;
		currentColor.b = 0f;

		Renderer screenShader2 = secondCube.GetComponent<Renderer>();
		if (typeKey == 0) 
		{
			currentColor.r = 1f;
			screenShader1.materials[0].SetColor ("_Color", currentColor);
			screenShader2.materials[0].SetColor ("_Color", currentColor);
		} else if (typeKey == 1) 
		{
			currentColor.g = 1f;
			screenShader1.materials[0].SetColor ("_Color", currentColor);
			screenShader2.materials[0].SetColor ("_Color", currentColor);
		} 
		else 
		{
			currentColor.b = 1f;
			screenShader1.materials[0].SetColor ("_Color", currentColor);
			screenShader2.materials[0].SetColor ("_Color", currentColor);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log ("Player detected");
			other.SendMessage("GiveKey", typeKey);

			if(keyUI != null)
				keyUI.gameObject.SetActive(true);

			Destroy(gameObject);
		} else {
			Debug.Log ("Alien detected");
		}
	}
}
