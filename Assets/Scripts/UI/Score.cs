﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text score;
	private float scoreCounter;

	void Start ()
	{
		// Calls the increaseScore function every 1 second and repeat it every 1 second.
		InvokeRepeating("increaseScore", 1, 1);
	}
		
	void FixedUpdate(){
		// Every second, update the score text.
		SetCountText ();
	}

	// Increase score by 1.
	void increaseScore(){
		scoreCounter++;
	}

	// Sets the score text.
	void SetCountText ()
	{
		score.text = "Score: " + scoreCounter.ToString ();
	}
}