using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameOverCountdown : MonoBehaviour {
	public Text countdownText;
	public float timeLeft;
	public PlayerHealth player;

	// Use this for initialization
	void Start () {
		countdownText.gameObject.SetActive(true);
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if(timeLeft > 0) {
			TimeSpan t = TimeSpan.FromSeconds(timeLeft);
			countdownText.text = string.Format("{0:D2}:{1:D2}.{2:D3}", t.Minutes, t.Seconds, t.Milliseconds);
		} else {
			player.OnDamage(9999);
		}
	}
}
