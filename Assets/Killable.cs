using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KillMask")
            Debug.Log("Right tag");
        //change value to level of kill. If its a swipe, lunge, etc.
        //other.gameObject.SendMessage("KillPerson", 1);
    }
}
