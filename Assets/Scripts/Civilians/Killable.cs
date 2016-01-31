using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {
    void Start()
    {
        var audio = GetComponent<AudioSource>();
        if (audio.isPlaying)
                audio.Pause();
    }
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
                var audio = GetComponent<AudioSource>();
                if (!audio.isPlaying)
                    audio.UnPause();
                var audio2 = GetComponentInParent<AudioSource>();
                if (!audio2.isPlaying)
                    audio2.UnPause();
            }
        }
    }
}
