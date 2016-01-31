using UnityEngine;
using System.Collections;

public class IntroTransition : MonoBehaviour {

	GameObject titleMusic = GameObject.Find ("TitleMusic");
	private float time;
	private int scene;
	// Use this for initialization
	void Start () {
		time = 0.0f;
		InvokeRepeating("Timer", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (time >= 4.0f) {
			scene = Application.loadedLevel;
			scene++;
			Application.LoadLevel(scene);
		}
	}

	void Timer(){
		time++;
	}
	public void StartGame(){
		Destroy (titleMusic);
		Debug.Log ("test");
		Application.LoadLevel (6);
	}
}
