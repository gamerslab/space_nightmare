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
	public float bulletSpeed;

	bool isDead = false;
	
	float timeBeforeDisappear = 5.0f;
	
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

	void Reached(){
		animation.CrossFade (attackAnimation.name);
		reached = true;
	}
	
	void NotReached(){
		animation.CrossFade (runAnimation.name);
		reached = false;
	}

	void Dead(){
		if (!isDead) {
			Destroy(gameObject.GetComponent<NavMeshAgent> ());
			Destroy(gameObject.GetComponent<CharacterController> ());
			isDead = true;
			PlayAnimation (deathAnimation.name, 0.0f, 1.29f);
		}
	}

	void isIddle()
	{
		animation.CrossFade (iddleAnimation.name);
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
