using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {

    //On collision with the vision infront of our player, die
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KillMask")
        {
            Debug.Log("Died");
        }
    }
}
