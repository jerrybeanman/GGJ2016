using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {

	// Max hunger point.
	public float maxHunger;
	// How fast the hunger bar goes up.
	public float recoveryRate;
	// Healthbar image.
	private Image image; 
	//public GameObject player;

	void Start()
	{
		image = GetComponent<Image> ();
		//player = GameObject.Find ("Player");
	}

	// Update is called once per frame
	void Update () 
	{
		// Fills the health bar getting the current position and moves it up using the recoveryRate up to maxHunger point.
		image.fillAmount = Mathf.MoveTowards(image.fillAmount, maxHunger, Time.deltaTime * recoveryRate);
		if (image.fillAmount == 1.0f) {
			Debug.Log ("game Over");
		}
	}

	void OnTriggerEnter(Collider2D other)
	{
		if (other.gameObject.tag == "Food")
		{
			Debug.Log ("touched Food");
			image.fillAmount -= 0.2f;
		}
	}
}
