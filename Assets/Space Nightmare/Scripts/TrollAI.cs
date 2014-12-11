using UnityEngine;
using System.Collections;

public class TrollAI : MonoBehaviour {
	NavMeshAgent agent;
	AnimationState anim;
	float endAnimationAtTime;
	
	private Vector3 _dir;
	float turnSpeed = 4.0f;

	public Rigidbody bulletFire;
	float fireRate = 0.5f;
	float interval;
	float accumulator;
	float fireMoment;
	Transform firePoint;
	bool hasFired;
	bool reached;

	bool isDead = false;
	
	float timeBeforeDisappear = 5.0f;
	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		
		accumulator = 0.0f;
		interval = 2.70f;
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
						bullet.AddForce (-firePoint.transform.forward * 400);
						hasFired = true;
				}
			} else {
				accumulator = 0.0f;
			}
			if (accumulator > 0.0f) {
					accumulator -= Time.deltaTime;
			}
		} else {
			if(anim && anim.enabled && anim.time >= endAnimationAtTime)
			{
				animation.Stop();
				anim.enabled = false;
			}
		}
		//		Vector3 nextPos = agent.steeringTarget;
	}
	
	void PlayAnimation(string nameOfAnimation, float startTime, float endTime) {
		anim = animation[nameOfAnimation];
		anim.time = startTime;
		anim.weight = 1;
		anim.enabled = true;
		endAnimationAtTime = endTime;
	}

	void Reached(string attackAnimation){
		animation.CrossFade (attackAnimation);
		reached = true;
	}
	
	void NotReached(string runAnimation){
		animation.CrossFade (runAnimation);
		reached = false;
	}

	void Dead(string nameDeadAnimation){
		if (!isDead) {
			Destroy(gameObject.GetComponent<NavMeshAgent> ());
			Destroy(gameObject.GetComponent<CharacterController> ());
			isDead = true;
			PlayAnimation (nameDeadAnimation, 0.0f, 1.29f);
		}
	}

	void isIddle(string iddleAnimation)
	{
		animation.CrossFade (iddleAnimation);
	}
}
