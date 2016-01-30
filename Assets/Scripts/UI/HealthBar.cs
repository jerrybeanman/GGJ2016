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

	void Start()
	{
		image = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () 
	{
		// Fills the health bar getting the current position and moves it up using the recoveryRate up to maxHunger point.
		image.fillAmount = Mathf.MoveTowards(image.fillAmount, maxHunger, Time.deltaTime * recoveryRate);
	}
}
