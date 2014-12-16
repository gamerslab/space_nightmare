using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadManager : MonoBehaviour {
	static private LoadManager m_Instance;

	public Image loadingImage;
	public Text loadingText;
	public AudioSource music;
	public float fadeDuration = 1.0f;

	float prevTimeSinceStartup;
	float accum = 0;
	string levelName;

	void Awake() {
		m_Instance = this;
		gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float delta = Time.realtimeSinceStartup - prevTimeSinceStartup;
		prevTimeSinceStartup += delta;
		
		if(accum <= fadeDuration) {
			float alpha = accum / fadeDuration;
			loadingImage.color = new Color(loadingImage.color.r, loadingImage.color.g, loadingImage.color.b, alpha);

			if(music != null)
				music.volume = 1 - alpha;

			accum += delta;
		} else {
			loadingText.gameObject.SetActive(true);
			Time.timeScale = 1;
			Application.LoadLevel(levelName);
		}
	}

	void _LoadLevel(string name) {
		levelName = name;
		Time.timeScale = 0;
		prevTimeSinceStartup = Time.realtimeSinceStartup;
		gameObject.SetActive(true);
	}

	static public void LoadLevel(string name) {
		m_Instance._LoadLevel (name);
	}
}
