using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

	GameObject PauseMenu;
	// Checks if the game is paused or not.
	bool paused;
	// Checks if the game is muted or not.
	bool muted;
	// Text change when the game muted.
	[SerializeField]
	Text muteText;

	// Use this for initialization
	void Start () {
		// When the game starts, make sures the game is not paused.
		paused = false;
		// Finds the game object PauseMenu and initializes it.
		PauseMenu = GameObject.Find("PauseMenu");
	}
	
	// Update is called once per frame
	void Update () {

		// When player presses Esc, game is paused or resume depending on paused bool state.
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}

		// Pauses the game and brings up the pause menu when bool paused is true.
		if (paused) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else if (!paused) {
			// Resumes the game and takes away the pause menu when bool paused is false.
			PauseMenu.SetActive (false);
			Time.timeScale = 1;
		}

		// Mutes the game if bool muted is true and changes the mute button text to "unmute".
		if (muted) {
			AudioListener.volume = 0;
			muteText.text = "Unmute";
		} else if (!muted) {
			//Unmutes the game if the bool muted is false and changes the mute button text to "mute".
			AudioListener.volume = 1;
			muteText.text = "Mute";
		}

	}

	// Button function to resume the game.
	public void Resume(){
		paused = false;
	}

	// Button function to go back to main menu.
	public void MainMenu(){
		Application.LoadLevel(1);
	}

	// Button function to mute the game.
	public void Mute(){
		muted = !muted;
	}

}

	