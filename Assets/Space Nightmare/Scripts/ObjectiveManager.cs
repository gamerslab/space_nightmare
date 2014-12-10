using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObjectiveManager : MonoBehaviour {
	static private ObjectiveManager m_Instance;
	static public ObjectiveManager Instance { get { return m_Instance; } }

	public Text currentObjective;
	public string firstObjective = "Unknown objective";
	public float showInterval = 2f;

	float showTime = 0;
	bool showed = false;

	void Awake() {
		m_Instance = this;
	}

	// Use this for initialization
	void Start () {
		NewObjective(firstObjective);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Show Objectives")) {
			currentObjective.gameObject.SetActive(true);
		}

		if(showTime > 0) {
			showTime -= Time.deltaTime;
		} else if(Input.GetButtonUp("Show Objectives") || showed) {
			currentObjective.gameObject.SetActive(false);
			showed = false;
		}
	}

	public void NewObjective(string objective) {
		currentObjective.text = objective;
		currentObjective.gameObject.SetActive(true);
		showed = true;
		showTime = showInterval;
	}
}
