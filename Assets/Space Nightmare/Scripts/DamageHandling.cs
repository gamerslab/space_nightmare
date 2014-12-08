using UnityEngine;
using System.Collections;

public class DamageHandling : MonoBehaviour {

	public int lifePoints;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnDamage(int damage)
	{
		lifePoints -= damage;
		Debug.Log (lifePoints);
		if (lifePoints <= 0) {
			gameObject.SendMessage("Dead");
//			Destroy(gameObject);
		}
	}
}
