using UnityEngine;
using System.Collections;

public class PathFindingTrial : MonoBehaviour {
	NavMeshAgent agent;
	AnimationState anim;
	float endAnimationAtTime;

	private Vector3 _dir;
	float turnSpeed = 4.0f;
	
	public Transform target;
	public Rigidbody bulletFire;
	float fireRate = 0.5f;
	float interval;
	float accumulator;
	float fireMoment;
	Transform firePoint;
	bool hasFired;

	public int lifePoints = 40;
	
	public AnimationClip deathAnimation;
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
		agent.SetDestination (target.position);

		float dist = agent.remainingDistance; 
		if (dist != Mathf.Infinity && agent.pathStatus == 
						NavMeshPathStatus.PathComplete && agent.remainingDistance <= agent.stoppingDistance) {
			_dir = target.position - transform.position;
			_dir.Normalize ();
			transform.rotation = Quaternion.Slerp 
		(transform.rotation, Quaternion.LookRotation (_dir), turnSpeed * Time.deltaTime);
			animation.CrossFade ("Attack_02");

			if (accumulator <= 0.0f) {
				hasFired = false;
				accumulator += interval;
			}
			else if(accumulator <= fireMoment && !hasFired)
			{
				Rigidbody bullet = Instantiate (bulletFire, firePoint.position, transform.rotation) as Rigidbody;
				bullet.AddForce (-firePoint.transform.forward * 400);
				hasFired = true;
			}
		} else {
			accumulator = 0.0f;
			animation.CrossFade ("Run");
		}
		if (accumulator > 0.0f)
		{
			accumulator -= Time.deltaTime;
			}
		} 
		else {
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
	
	void Dead()
	{
		if (!isDead) {
			isDead = true;
			gameObject.GetComponent<CharacterController>().isTrigger = true;
			agent.Stop ();

			animation [deathAnimation.name].wrapMode = WrapMode.ClampForever;
			PlayAnimation (deathAnimation.name, 0.0f, 1.29f);
			animation.Play(deathAnimation.name);
			Debug.Log (deathAnimation.length);
			Destroy (this.gameObject, deathAnimation.length + timeBeforeDisappear);
		}
	}


}
//void Update () {
//	na.destination = destination.gameObject.transform.position;
//	sprite.RotateTowards(new Vector2(na.steeringTarget.x,na.steeringTarget.z));                            
//}
