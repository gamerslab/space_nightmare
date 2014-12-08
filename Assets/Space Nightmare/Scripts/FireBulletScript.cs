﻿using UnityEngine;
using System.Collections;

public class FireBulletScript : MonoBehaviour {
	public GameObject explosion;
	public float damageRadius = 5f;
	public float damageAtCenter = 20f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(){
		GameObject b = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
		ParticleSystem p = b.GetComponent<ParticleSystem>();
		p.Play();
		p.gameObject.AddComponent("ParticleSystemAutoDestroy");

		foreach(Collider collider in Physics.OverlapSphere(transform.position, damageRadius)) {
			if(collider.gameObject.tag == "Player") {
				RaycastHit hit;
				bool exposed = false;

				if(Physics.Raycast(transform.position, collider.transform.position - transform.position, out hit)) {
					exposed = (hit.collider == collider);
				}

				if(exposed) {
					float distance = Vector3.Distance(transform.position, collider.transform.position);
					int damageValue = Mathf.CeilToInt(damageAtCenter - damageAtCenter * (distance / damageRadius));

					collider.SendMessage("OnDamage", damageValue);
					Debug.Log("Firebullet hit. Damage: " + damageValue);
				}
			}
		}

		Destroy(gameObject);
	}
}