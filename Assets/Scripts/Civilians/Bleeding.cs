using UnityEngine;
using System.Collections;

public class Bleeding : MonoBehaviour {
    float TimerMax = 5;
    float endScale = 1;
    float timer;
	// Use this for initialization
	void Start () {
        timer = TimerMax;
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
            timer -= Time.deltaTime;
    }
}
