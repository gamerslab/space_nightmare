using UnityEngine;
using System.Collections;

[RequireComponent (typeof(ParticleSystem))]
public class ParticleSystemAutoDestroy : MonoBehaviour {
	ParticleSystem ps;

	// Use this for initialization
	void Start () {
		ps = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(!ps.IsAlive()) {
			Destroy(gameObject);
		}
	}
}
