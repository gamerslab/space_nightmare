using UnityEngine;
using System.Collections;

public class FireBulletScript : MonoBehaviour {
	GameObject explosion;

	// Use this for initialization
	void Start () {
		explosion = transform.Find ("Explosion").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(){
		GameObject b = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
		ParticleSystem p = b.GetComponent<ParticleSystem>();
		p.Play();
		p.gameObject.AddComponent("ParticleSystemAutoDestroy");

		Destroy(gameObject);
	}
}
