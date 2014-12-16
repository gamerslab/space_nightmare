using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 100;
	public int currentHealth = 100;
	public Image damageImage;
	public Slider healthBar;
	public Color flashColor = new Color(1f, 0, 0, 1f);
	public float flashSpeed = 3f;

	bool damaged = false;
	bool isDead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(damaged) {
			damageImage.color = flashColor;
			damaged = false;
		} else {
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
	}

	void OnDamage(int damage) {
		damaged = true;
		currentHealth -= damage;

		if(currentHealth < 0) {
			currentHealth = 0;
			isDead = true;
		}

		healthBar.value = currentHealth;
	}

	void HealthRecharge(int amount)
	{
		currentHealth = Mathf.Min(maxHealth,currentHealth+amount);
		healthBar.value = currentHealth;
	}
}
