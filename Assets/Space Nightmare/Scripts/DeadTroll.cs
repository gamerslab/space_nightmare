using UnityEngine;
using System.Collections;

public class DeadTroll : MonoBehaviour {
	
	public AnimationClip deathAnimation;
	AnimationState anim;
	float endAnimationAtTime;
	float startTime;
	// Use this for initialization
	void Start () {
//		animation[deathAnimation.name].wrapMode = WrapMode.ClampForever;
		animation[deathAnimation.name].time = 1.25f;
		animation[deathAnimation.name].speed = 0.0f;
		animation.Play(deathAnimation.name);
		Destroy(gameObject.GetComponent<CharacterController>());
		Destroy(gameObject.GetComponent<NavMeshAgent>());
//		startTime = anim.time;
//		anim.weight = 1;
//		anim.enabled = true;
//		animation.Play (deathAnimation.name);
//		endAnimationAtTime = 8f*1.3f+1.25f;
//		animation.Stop();
//		anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
//		startTime += Time.deltaTime;
//		if(anim && anim.enabled && startTime >= endAnimationAtTime)
//		{
//			Destroy(gameObject.GetComponent<CharacterController>());
//			Destroy(gameObject.GetComponent<NavMeshAgent>());
//			animation.Stop();
//			anim.enabled = false;
//		}
	}
}
