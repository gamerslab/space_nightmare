using UnityEngine;
using System.Collections;

public class SpiderAI : MonoBehaviour {
	bool isDead = false;
	bool reached = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void Dead(string animationName)
	{
		if (!isDead) {
			Destroy(gameObject.GetComponent<BoxCollider> ());
			Destroy(gameObject.GetComponent<NavMeshAgent> ());
			isDead = true;
		}
	}

	void Reached(string attackAnimation){
		animation.CrossFade (attackAnimation);
		reached = true;
	}
	
	void NotReached(string runAnimation){
		animation.CrossFade (runAnimation);
		reached = false;
	}
	
	void isIddle(string iddleAnimation)
	{
		animation.CrossFade (iddleAnimation);
	}
}                  
