using UnityEngine;
using System.Collections;

public class MachineGunController : MonoBehaviour {
	// Number of bullets per second
	public int fireRate = 9;
	public int ammoPerMagazine = 120;
	public int ammoMax = 360;
	public float damage = 5.0f;

	ParticleSystem shootAnimation;
	GameObject bang;
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
		bang = transform.Find ("Bang").gameObject;
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
				RaycastHit hit;
				Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
				Debug.DrawRay(Camera.main.transform.position, fwd * 10, Color.red, 2, true);

				if(Physics.Raycast(Camera.main.transform.position, fwd, out hit, 100, Physics.kDefaultRaycastLayers)) {
					GameObject b = (GameObject) Instantiate(bang, hit.point, Quaternion.LookRotation(hit.normal));
					ParticleSystem p = b.GetComponent<ParticleSystem>();
					p.Play();
					p.gameObject.AddComponent("ParticleSystemAutoDestroy");

					GameObject obj = hit.collider.gameObject;
					if(obj.tag == "Enemy") {
						obj.SendMessage("OnDamage",1);
						Debug.Log("Enemy hit");
					} else {

					}
				}
			}
		} else {
			accumulator -= Time.deltaTime;
		}
	}
}
