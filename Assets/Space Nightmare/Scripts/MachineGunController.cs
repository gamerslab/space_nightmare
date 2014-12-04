using UnityEngine;
using System.Collections;

public class MachineGunController : MonoBehaviour {
	// Number of bullets per second
	public int fireRate = 9;
	public int ammoPerMagazine = 120;
	public int ammoMax = 360;
	public float damage = 5.0f;

	ParticleSystem shootAnimation;
	int currentAmmo;
	int storeAmmo;
	float accumulator;
	float interval;

	// Use this for initialization
	void Start () {
		shootAnimation = 
			transform.Find ("Effects")
				.transform.Find ("WeaponRoot")
				.transform.Find ("Particle System")
				.GetComponent<ParticleSystem> ();
		currentAmmo = ammoPerMagazine;
		storeAmmo = ammoMax - currentAmmo;
		accumulator = 0;
		interval = 1.0f / fireRate;
	}
	
	// Update is called once per frame
	void Update () {
		if(accumulator <= 0) {
			if(Input.GetButton("Fire1")) {
				shootAnimation.Stop ();
				shootAnimation.Play();
				accumulator += interval;
				// Shoot logic here
			}
		} else {
			accumulator -= Time.deltaTime;
		}
	}
}
