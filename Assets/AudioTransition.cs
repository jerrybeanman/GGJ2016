using UnityEngine;
using System.Collections;

public class AudioTransition : MonoBehaviour {

	GameObject titleMusic = GameObject.Find("TitleMusic");
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake(){
		DontDestroyOnLoad (gameObject);
		if (Application.loadedLevel == 6) {
			Destroy (titleMusic);
		}
	}
}