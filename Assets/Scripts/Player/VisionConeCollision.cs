using UnityEngine;
using System.Collections;

public class VisionConeCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DashToEnemy(GameObject target)
    {
        transform.parent.gameObject.SendMessage("DashToEnemy", target);
    }
}
