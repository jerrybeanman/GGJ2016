using UnityEngine;
using System.Collections;

/*
Carson:
Quick PlayerRotation to look at mouse script.
*/

public class PlayerRotation : MonoBehaviour {
    Vector3 curPos;
    Vector3 lastPos;
    //Updates the characters rotation every frame
    void FixedUpdate() {
        if (Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") != 0 && GetComponent<Rigidbody2D>().velocity.magnitude >= 0.8)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, GetComponent<Rigidbody2D>().velocity);
        } 
    }
}