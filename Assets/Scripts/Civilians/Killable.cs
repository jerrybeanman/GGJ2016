using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {

    //On collision with the vision infront of our player, die
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "KillMask")
        {
            RaycastHit2D hit;
            hit = Physics2D.Linecast(transform.position, GameObject.Find("Player 1").transform.position, 1 << LayerMask.NameToLayer("Wall"));
            if (hit.collider == null)
            {
                other.SendMessage("DashToEnemy", this.gameObject);
            }
        }
    }
}
