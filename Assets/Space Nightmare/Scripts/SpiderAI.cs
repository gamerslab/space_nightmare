using UnityEngine;
using System.Collections;

public class SpiderAI : MonoBehaviour {
	// Variables to know the state
	bool isDead = false;
	bool reached = false;

	// Attack variables
	float interval;
	float accumulator;
	float fireMoment;
	bool hasFired;
	float rangeAttack;
	public float damageValue;

	// Target information
	Transform target;
	float currentDistance;

	// Animations
	AnimationClip attackAnimation;
	AnimationClip runAnimation;
	AnimationClip iddleAnimation;

	public AudioClip attackAudio;


	// Use this for initialization
	void Start () {
		accumulator = 0.0f;
		Debug.Log ("Interval: " + interval);
		fireMoment = 0.9f/3.0f;
		rangeAttack = transform.GetComponent<NavMeshAgent> ().stoppingDistance;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			if (reached) {
				if (accumulator <= 0.0f) {
					hasFired = false;
					accumulator += interval;
				} else if (accumulator <= fireMoment && !hasFired) {
					currentDistance = Vector2.Distance(new Vector2(transform.position.x,transform.position.z),
					                                   new Vector2(target.position.x,target.position.z));
					if (currentDistance < rangeAttack && Mathf.Abs(transform.position.y-target.position.y)<1.0f)
					{
						target.gameObject.SendMessage("OnDamage", damageValue);
						AudioSource.PlayClipAtPoint (attackAudio, transform.position);
					}
					hasFired = true;
				}
			} else {
				accumulator = 0.0f;
			}
			if (accumulator > 0.0f) {
				accumulator -= Time.deltaTime;
			}
		}
	}

	void Dead(string animationName)
	{
		if (!isDead) {
			Destroy(gameObject.GetComponent<BoxCollider> ());
			Destroy(gameObject.GetComponent<NavMeshAgent> ());
			isDead = true;
		}
	}

	void Reached() {
		animation.CrossFade (attackAnimation.name);
		reached = true;
	}
	
	void NotReached(){
		animation.CrossFade (runAnimation.name);
		reached = false;
	}
	
	void isIddle()
	{
		animation.CrossFade (iddleAnimation.name);
	}

	void setTarget(Transform target)
	{
		this.target = target;
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

	}
}                  
