using UnityEngine;
using System.Collections;

public class PressurePlateCollision : MonoBehaviour {
    private bool active;
    private Vector3 side;

    //Default to not transparent roofs
	void Start () {
        active = false;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
    }

    //If the player touches the roofs, make them transparent
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach(var sprRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                sprRenderer.color = new Color(1f, 1f, 1f, 0f);
            }
        }
    }

    //If they stop touching it, make them not transparent
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (var sprRenderer in GetComponentsInChildren<SpriteRenderer>())
            {
                sprRenderer.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }
}
