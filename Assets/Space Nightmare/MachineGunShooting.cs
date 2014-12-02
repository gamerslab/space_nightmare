using UnityEngine;
using System.Collections;

public class MachineGunShooting : MonoBehaviour {
	public ParticleSystem ShootSystem;
	public GameObject MachineGun;
	public int delayShoot;
	bool shooting = false;
	int maxDelay = 6;

	// Use this for initialization
	void Start () {
		delayShoot = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (shooting) {
			if (delayShoot > 0) {
				if (delayShoot == maxDelay) {
					MachineGun.transform.Translate (0.01f, 0.0f, 0.0f);
				}
				if (delayShoot == maxDelay / 2) {
					MachineGun.transform.Translate (-0.01f, 0.0f, 0.0f);
				}
				delayShoot--;
				if (delayShoot == 0) {
					delayShoot = maxDelay;
				}
			}
		}
		if (Input.GetMouseButtonDown(0))
		{
			shooting = true;
			if (delayShoot == 0) {
				delayShoot = maxDelay;
			}
			ShootSystem.Play();
		}
		if (Input.GetMouseButtonUp(0))
		{
			shooting = false;
			ShootSystem.Stop();
		}
	}
}
