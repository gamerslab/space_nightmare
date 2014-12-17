using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour {
	static private DialogManager m_Instance;

	public float charsPerSecond = 20.0f;
	public Text dialogText;
	public delegate void Callback();

	Queue dialogQueue = new Queue();
	int subdialog = 0;
	float accum = 0;
	float prevTimeSinceStartup;
	float charInterval;
	Callback afterDialog;
	
	void Awake () {
		m_Instance = this;
		charInterval = 1 / charsPerSecond;
		gameObject.SetActive (false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float delta = Time.realtimeSinceStartup - prevTimeSinceStartup;
		prevTimeSinceStartup += delta;

		if(dialogQueue.Count > 0) {
			string[] subdialogs = (dialogQueue.Peek() as string).Split('|');
			string dialog = "";

			for(int i = 0; i < subdialog; ++i) {
				dialog += subdialogs[i];
			}

			string current = subdialogs[subdialog];
			int length = Mathf.Min(current.Length, (int)(accum / charInterval));

			dialogText.text = dialog + current.Substring(0, length);
			accum += delta;

			if(length == current.Length && Input.GetButton("Fire1")) {
				if(subdialog >= subdialogs.Length - 1) {
					dialogQueue.Dequeue();
					subdialog = 0;
				} else {
					subdialog++;
				}

				accum = 0;
			}
		} else {
			Time.timeScale = 1;
			gameObject.SetActive(false);

			if(afterDialog != null)
				afterDialog();
		}
	}

	void _Add(string[] dialogs, Callback callback) {
		foreach (string dialog in dialogs) {
			dialogQueue.Enqueue (dialog);
		}
		
		subdialog = 0;
		afterDialog = callback;
		prevTimeSinceStartup = Time.realtimeSinceStartup;
		Time.timeScale = 0;
		dialogText.text = "";
		gameObject.SetActive (true);
	}

	static public void Add(params string[] dialogs){
		m_Instance._Add (dialogs, null);
	}

	static public void Add(Callback callback, params string[] dialogs){
		m_Instance._Add (dialogs, callback);
	}
}
