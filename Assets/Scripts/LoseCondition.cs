using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoseCondition : MonoBehaviour {
	public static LoseCondition Instance { get; private set; }
	public Text finalScore;

	[HideInInspector]
	GameObject GameOverMenu;
	public bool gameStatus = false;
	public float finalScoreCounter = 0.0f;

	// Use this for initialization
	void Start () {
		GameOverMenu = GameObject.Find("GameOverMenu");
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);

		GameOverMenu.SetActive (false);
	}

	void Update(){
		if (gameStatus == false) {
			GameOverMenu.SetActive (false);
		} else if (gameStatus == true) {
			GameOverMenu.SetActive (true);
			Time.timeScale = 0;
			finalScore.text = "Your final score is: " + finalScoreCounter.ToString ();
		}
	}

	public void restart(){
		Application.LoadLevel(1);
	}

}
