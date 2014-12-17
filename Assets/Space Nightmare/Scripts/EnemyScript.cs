using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	// Movement handling
	NavMeshAgent agent;
	public Transform target;
	private Vector3 _dir;
	float turnSpeed = 4.0f;
	public AnimationClip runAnimation;
	public float runningSpeed;

	// Attack handling
	float fireRate = 0.5f;
	public float fireMoment;
	public AnimationClip attackAnimation;

	// Life handling
	public int lifePoints;
	float timeBeforeDisappear = 5.0f;
	public AnimationClip deathAnimation;
	bool isDead = false;

	public AnimationClip iddleAnimation;

	public float likelihoodPrice;
	int likelihoodPriceInt;
	public GameObject price;

	public AudioClip nearbyAudio;
	public AudioClip hurtAudio;
	public AudioClip deathAudio;
	public float playNearbySeconds = 5.0f;
	float accum = 0;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		likelihoodPriceInt = Mathf.FloorToInt (likelihoodPrice * 100);

		fireMoment = 1.0f;
		animation[runAnimation.name].speed = runningSpeed;
		animation.CrossFade (runAnimation.name);

		gameObject.SendMessage("setTarget", target);
		gameObject.SendMessage("setAttackAnimation", attackAnimation);
		gameObject.SendMessage("setRunAnimation", runAnimation);
		gameObject.SendMessage("setIddleAnimation", iddleAnimation);
		gameObject.SendMessage("setDeathAnimation", deathAnimation);
	}
	
	// Update is called once per frame
	void Update () {
		if(isDead)
			return;

		if (Vector3.Distance(Camera.main.transform.position,transform.position) > 25.0f)
		{
			gameObject.SendMessage("isIddle", iddleAnimation.name);
		}
		else
		{
			agent.SetDestination (target.position);
			
			float dist = agent.remainingDistance; 
			if (dist != Mathf.Infinity && agent.pathStatus == 
			    NavMeshPathStatus.PathComplete && agent.remainingDistance <= agent.stoppingDistance &&
			    Vector3.Distance(transform.position, target.transform.position) <= agent.stoppingDistance) {
				_dir = target.position - transform.position;
				_dir.Normalize ();
				transform.rotation = 
					Quaternion.Slerp (transform.rotation, 
					                  Quaternion.LookRotation (_dir), turnSpeed * Time.deltaTime);
				gameObject.SendMessage("Reached", attackAnimation.name);
			} else {
				if(accum <= 0) {
					AudioSource.PlayClipAtPoint(nearbyAudio, transform.position);
					accum = playNearbySeconds;
				} else {
					accum -= Time.deltaTime;
				}

				gameObject.SendMessage("NotReached", runAnimation.name);
			}
			if (dist == Mathf.Infinity)
			{
				gameObject.SendMessage("NotReached", runAnimation.name);
			}
		}
	}

	void OnDamage(int damage)
	{
		lifePoints -= damage;
		AudioSource.PlayClipAtPoint(hurtAudio, transform.position);
		
		if (lifePoints <= 0 && !isDead) {
			lifePoints = 0;

			if (price != null && Random.Range(0,100) <= likelihoodPriceInt)
			{
				Vector3 boxPosition = transform.position;
				boxPosition.y = 0.37f;
				Instantiate (price, boxPosition, 
				             Quaternion.AngleAxis(90,Vector3.left)); 
			}

			agent.Stop();
			animation[deathAnimation.name].wrapMode = WrapMode.ClampForever;
			animation.Play(deathAnimation.name);
			isDead = true;
			gameObject.SendMessage("Dead", deathAnimation.name);
		}
	}

	void Reached(){
		
	}
	
	void NotReached(){
		
	}
	
	void Dead() {
		AudioSource.PlayClipAtPoint (deathAudio, transform.position);
	}
	
	void SetTarget(Transform sentTarget){
		target = sentTarget;
	}
}
