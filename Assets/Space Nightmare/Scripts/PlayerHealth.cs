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
	public AudioClip hurtAudio;

	bool damaged = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale == 0)
			return;

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
			Time.timeScale = 0;
		}

		healthBar.value = currentHealth;
		AudioSource.PlayClipAtPoint (hurtAudio, Camera.main.transform.position);
	}

	void HealthRecharge(int amount)
	{
		currentHealth = Mathf.Min(maxHealth,currentHealth+amount);
		healthBar.value = currentHealth;
	}

	void Dead() {

	}
}
