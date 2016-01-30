using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	public Text score;
	private float count;

	void Start ()
	{
		InvokeRepeating("increaseScore", 1, 1);
	}

	void FixedUpdate(){
		SetCountText ();
	}
	void increaseScore(){
		count++;
	}

	void SetCountText ()
	{
		score.text = "Score: " + count.ToString ();
	}
}