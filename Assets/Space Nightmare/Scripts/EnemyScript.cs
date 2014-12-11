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


	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		likelihoodPriceInt = Mathf.FloorToInt (likelihoodPrice * 100);

		fireMoment = 1.0f;
		animation[runAnimation.name].speed = runningSpeed;
		animation.CrossFade (runAnimation.name);
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(Camera.main.transform.position,transform.position) > 25.0f)
		{
			gameObject.SendMessage("isIddle", iddleAnimation.name);
		}
		else
		{
			if (!isDead) {
				agent.SetDestination (target.position);
				
				float dist = agent.remainingDistance; 
				if (dist != Mathf.Infinity && agent.pathStatus == 
				    NavMeshPathStatus.PathComplete && agent.remainingDistance <= agent.stoppingDistance) {
					_dir = target.position - transform.position;
					_dir.Normalize ();
					transform.rotation = 
						Quaternion.Slerp (transform.rotation, 
						                  Quaternion.LookRotation (_dir), turnSpeed * Time.deltaTime);
	//				animation.CrossFade (attackAnimation.name);
					gameObject.SendMessage("Reached", attackAnimation.name);
				} else {
					gameObject.SendMessage("NotReached", runAnimation.name);
	//				animation.CrossFade (runAnimation.name);
				}
				//		Vector3 nextPos = agent.steeringTarget;
			}
		}
	}

	void OnDamage(int damage)
	{
		lifePoints -= damage;
		Debug.Log (lifePoints);
		if (lifePoints <= 0 && !isDead) {
			if (Random.Range(0,100) <= likelihoodPriceInt)
			{
				Vector3 boxPosition = transform.position;
				boxPosition.y = 0.37f;
				Instantiate (price, boxPosition, 
				             Quaternion.AngleAxis(90,Vector3.left)); 
			}
			agent.Stop();
			//			gameObject.GetComponent<BoxCollider>().isTrigger = true;
			
			animation[deathAnimation.name].wrapMode = WrapMode.ClampForever;
			animation.Play(deathAnimation.name);
			Debug.Log(deathAnimation.length);
			Destroy(this.gameObject, deathAnimation.length+timeBeforeDisappear);
			isDead = true;
			gameObject.SendMessage("Dead",deathAnimation.name);
		}
	}

	void Reached(){
		
	}
	
	void NotReached(){
		
	}
	
	void Dead(){
		
	}
	
	void SetTarget(Transform sentTarget){
		target = sentTarget;
	}
}
