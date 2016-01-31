using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
    float hour = 0;
	public float timeSpeed = 0.005f;
	public float maxDarkness = 0.5f;
	public float minDarkness = 0.0f;

    void Start()
    {
        transform.localScale += new Vector3(70, 40, 0);
    }
	
	// Update is called once per frame
	void Update () {
        var loc = GameObject.Find("Player 1").transform.position;
        loc.z = -50;
        transform.position = loc;

        float alpha = 1- Mathf.Abs((hour % 24) - 12)/12;
        if (alpha > maxDarkness)
            alpha = maxDarkness;
        else if (alpha < minDarkness)
            alpha = minDarkness;
        hour += timeSpeed;
        GetComponent<SpriteRenderer>().color =  new Color(1f, 1f, 1f, alpha);
    }
}
