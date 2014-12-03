using UnityEngine;
using System.Collections;

public class SpiderIA : MonoBehaviour {
	public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		animation.CrossFade ("walk");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0.0f,0.0f,speed*Time.deltaTime);
	}
}
