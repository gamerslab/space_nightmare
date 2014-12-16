﻿using UnityEngine;
using System.Collections;

public class TriggerActivator : MonoBehaviour {
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			target.SetActive(true);
		}
	}
}