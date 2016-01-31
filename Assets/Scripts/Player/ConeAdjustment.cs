using UnityEngine;
using System.Collections;

public class ConeAdjustment : MonoBehaviour {

	private GameObject cone;
	public float coneX = 0.2f;
	public float coneY = 0.3f;


	// Use this for initialization
	void Start () {
		cone = GameObject.Find ("VisionCone");

	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector2 (coneX, coneY);
		if (HealthBar.Instance.image.fillAmount >= 0.2f) {
			coneX = HealthBar.Instance.image.fillAmount;
		}
		if (HealthBar.Instance.image.fillAmount >= 0.3f) {
			coneY = HealthBar.Instance.image.fillAmount;
		}
	}
}
