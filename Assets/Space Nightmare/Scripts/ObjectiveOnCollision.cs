using UnityEngine;
using System.Collections;

public class ObjectiveOnCollision : MonoBehaviour {
	public string newObjective;
	public GameObject nextTargetActivator;
	public bool isActivated;
	public GameObject targetObject;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void activateTarget()
	{
		GetComponent<BoxCollider>().enabled = true;
		isActivated = true;
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("First position");
		if (isActivated) 
		{
			Debug.Log ("Second position");
			if (other.tag == "Player") {
				Debug.Log ("Third position");
				ObjectiveManager.Instance.NewObjective (newObjective);
				nextTargetActivator.SendMessage ("activateTarget");
				Destroy (targetObject);
				Destroy (gameObject);
			}
		}
	}
}
