using UnityEngine;
using System.Collections;

public class PressurePlateCollision : MonoBehaviour {
    private bool active;
	// Use this for initialization
	void Start () {
        active = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (active)
                GetComponentInParent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            else
                GetComponentInParent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
