using UnityEngine;
using System.Collections;

public class AssignPhoto : MonoBehaviour {
	public Texture myTexture;
	// Use this for initialization
	void Start () {
		renderer.materials [1].mainTexture = myTexture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
