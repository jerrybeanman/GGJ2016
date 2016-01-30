using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

	GameObject PauseMenu;
	bool paused;
	bool muted;
	[SerializeField]
	Text muteText;

	// Use this for initialization
	void Start () {
		paused = false;
		PauseMenu = GameObject.Find("PauseMenu");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}

		if (paused) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else if (!paused) {
			PauseMenu.SetActive (false);
			Time.timeScale = 1;
		}

		if (muted) {
			AudioListener.volume = 0;
			muteText.text = "UnMute";
		} else if (!muted) {
			AudioListener.volume = 1;
			muteText.text = "Mute";
		}

	}
	public void Resume(){
		paused = false;
	}

	public void MainMenu(){
		Application.LoadLevel(1);
	}

	public void Mute(){
		muted = !muted;
	}

}

	