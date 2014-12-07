using UnityEngine;
using System.Collections;

public class PathFindingTrial : MonoBehaviour {
	NavMeshAgent agent;

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
//		Vector3 nextPos = agent.steeringTarget;
	}
}
//void Update () {
//	na.destination = destination.gameObject.transform.position;
//	sprite.RotateTowards(new Vector2(na.steeringTarget.x,na.steeringTarget.z));                            
//}
