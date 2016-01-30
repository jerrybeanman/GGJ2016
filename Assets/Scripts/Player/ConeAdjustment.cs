using UnityEngine;
using System.Collections;

public class ConeAdjustment : MonoBehaviour {

	private GameObject cone;
	private float coneX = 0.2f;
	private float coneY = 0.3f;


	// Use this for initialization
	void Start () {
		cone = GameObject.Find ("VisionCone");

	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector2 (coneX, coneY);
		if (coneX >= 0.5f) {
			transform.localScale = new Vector2 (0.5f, coneY);
		}
		if (HealthBar.Instance.image.fillAmount >= 0.2f) {
			coneX = HealthBar.Instance.image.fillAmount;
		}
		if (HealthBar.Instance.image.fillAmount >= 0.3f) {
			coneY = HealthBar.Instance.image.fillAmount;
		}
	}
}
