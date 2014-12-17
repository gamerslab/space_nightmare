using UnityEngine;
using System.Collections;

public class TrollAI : MonoBehaviour {
	public Rigidbody bulletFire;
	public float bulletSpeed;

	NavMeshAgent agent;
    Vector3 _dir;
	float turnSpeed = 4.0f;

	float fireRate = 0.5f;
	float interval;
	float accumulator;
	float fireMoment;

	Transform firePoint;

	bool hasFired;
	bool reached;
	bool isDead = false;
	
	// Animations
	AnimationClip attackAnimation;
	AnimationClip runAnimation;
	AnimationClip iddleAnimation;
	AnimationClip deathAnimation;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		
		accumulator = 0.0f;
		fireMoment = 1.0f;
		firePoint = transform.Find ("FirePoint");
		hasFired = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			if (reached) {
				if (accumulator <= 0.0f) {
					hasFired = false;
					accumulator += interval;
				} else if (accumulator <= fireMoment && !hasFired) {
					Rigidbody bullet = Instantiate (bulletFire, firePoint.position, transform.rotation) as Rigidbody;
					firePoint.transform.LookAt(Camera.main.transform.position);
					bullet.AddForce (firePoint.transform.forward * bulletSpeed);
					hasFired = true;
				}
			}
		} else if(accumulator <= 0) {
			animation.Stop();
		}

		if(accumulator > 0.0f) {
			accumulator -= Time.deltaTime;
		} else {
			accumulator = 0f;
		}
	}

	void Reached(){
		animation.CrossFade (attackAnimation.name);
		reached = true;
	}
	
	void NotReached(){
		RaycastHit hit;

		if (Physics.Raycast (firePoint.transform.position, Camera.main.transform.position - firePoint.transform.position, out hit)) {
			if(hit.collider.tag == "Player") {
				Reached();
				return;
			}
		}

		animation.CrossFade (runAnimation.name);
		reached = false;
	}

	void Dead(){
		if (!isDead) {
			Destroy(gameObject.GetComponent<NavMeshAgent> ());
			Destroy(gameObject.GetComponent<CharacterController> ());
			isDead = true;
			accumulator = 1.25f;
		}
	}

	void isIddle()
	{
		animation.CrossFade (iddleAnimation.name);
	}

	void setTarget(Transform target) {

	}

	void setAttackAnimation(AnimationClip attackAnimation)
	{
		this.attackAnimation = attackAnimation;
		interval = attackAnimation.length;
	}
	
	void setRunAnimation(AnimationClip runAnimation)
	{
		this.runAnimation = runAnimation;
	}
	
	void setIddleAnimation(AnimationClip iddleAnimation)
	{
		this.iddleAnimation = iddleAnimation;
	}
	
	void setDeathAnimation(AnimationClip deathAnimation)
	{
		this.deathAnimation = deathAnimation;
	}
}
