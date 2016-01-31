using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager: MonoBehaviour {
	public static GameManager Instance { get; private set; }
	public Text FinalScore;
	
	[HideInInspector]
	GameObject GameOverMenu;
	public float finalScoreCounter = 0.0f;
	public bool gameStatus = false;
	
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
			Time.timeScale = 1;
		} else if (gameStatus == true) {
			Time.timeScale = 0;
			FinalScore.text = "Your final score is: " + finalScoreCounter.ToString ();
			GameOverMenu.SetActive (true);

		}
	}
	
}