using UnityEngine;
using System.Collections;

public class ConeAdjustment : MonoBehaviour {

	private GameObject cone;
	private float coneX;
	private float coneY;


	// Use this for initialization
	void Start () {
		cone = GameObject.Find ("VisionCone");

	}
	
	// Update is called once per frame
	void Update () {
		if (HealthBar.Instance.image.fillAmount <= 1.0f) {
			coneX = HealthBar.Instance.image.fillAmount;
			coneY = HealthBar.Instance.image.fillAmount;
			if (coneX <= 0.5f) {
				transform.localScale = new Vector2 (coneY, 0.5f);
			}
			if (coneY <= 1.0f) {
				transform.localScale = new Vector2 (1.0f, coneX);
			}
			transform.localScale = new Vector2 (coneY, coneX);
		}
	}
}
