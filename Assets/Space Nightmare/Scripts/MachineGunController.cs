using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MachineGunController : MonoBehaviour {
	// Number of bullets per second
	public int fireRate = 9;
	public int ammoPerMagazine = 120;
	public int ammoMax = 360;
	public int damage = 1;
	public ParticleSystem shootAnimation;
	public ParticleSystem bang;
	public Text currentAmmoUI;
	public Text storeAmmoUI;

	int currentAmmo;
	int storeAmmo;
	float accumulator;
	float interval;
	bool reload;

	// Use this for initialization
	void Start () {
		currentAmmo = ammoPerMagazine;
		storeAmmo = ammoMax - currentAmmo;
		accumulator = 0;
		interval = 1.0f / fireRate;
		reload = false;
		currentAmmoUI.text = currentAmmo.ToString();
		storeAmmoUI.text = storeAmmo.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(accumulator <= 0) {
			if(reload) {
				int ammoToLoad = ammoPerMagazine - currentAmmo;

				if(ammoToLoad <= storeAmmo) {
					currentAmmo = ammoPerMagazine;
					storeAmmo -= ammoToLoad;
				} else {
					currentAmmo += storeAmmo;
					storeAmmo = 0;
				}

				currentAmmoUI.text = currentAmmo.ToString();
				storeAmmoUI.text = storeAmmo.ToString();
				reload = false;
			}

			if(Input.GetButton("Fire1")) {
				if(currentAmmo > 0) {
					Shoot();
				} else {
					Reload();
				}
			} else if(Input.GetButton("Reload")) {
				Reload ();
			}
		} else {
			accumulator -= Time.deltaTime;
		}
	}

	void Shoot() {
		shootAnimation.Stop ();
		shootAnimation.Play();
		accumulator += interval;
		currentAmmo -= 1;
		currentAmmoUI.text = currentAmmo.ToString();
		
		// Shoot logic
		RaycastHit hit;
		Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(Camera.main.transform.position, fwd * 10, Color.red, 2, true);
		
		if(Physics.Raycast(Camera.main.transform.position, fwd, out hit, 100, Physics.kDefaultRaycastLayers)) {
			ParticleSystem p = Instantiate(bang, hit.point, Quaternion.LookRotation(hit.normal)) as ParticleSystem;
			p.Play();
			p.gameObject.AddComponent("ParticleSystemAutoDestroy");
			
			GameObject obj = hit.collider.gameObject;
			if(obj.tag == "Enemy") {
				obj.SendMessage("OnDamage", damage);
				Debug.Log("Enemy hit");
			}
		}
	}

	void Reload() {
		if(currentAmmo < ammoPerMagazine && storeAmmo > 0) {
			accumulator = animation.clip.length;
			animation.Play();
			reload = true;
		}
	}

	void AmmoRecharge(int ammount)
	{
		storeAmmo = Mathf.Min (ammoMax, storeAmmo+ammount);
		storeAmmoUI.text = storeAmmo.ToString();
	}
}
