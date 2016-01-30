using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public float curHunger;
	public float maxHunger;
	public float recoveryRate;

	private Image image;
	void Start()
	{
		image = GetComponent<Image> ();
	}
	// Update is called once per frame
	void Update () 
	{
		
		image.fillAmount = Mathf.MoveTowards(image.fillAmount, maxHunger, Time.deltaTime * recoveryRate);
	}
}
