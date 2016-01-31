using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {
	AudioSource audio;
	AudioSource ParentAudio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
		ParentAudio = transform.parent.gameObject.GetComponent<AudioSource>();
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
				Debug.Log("asdfasdf");
				audio.Play();
				ParentAudio.Play();
				/*AudioSource.PlayClipAtPoint(audio.clip, transform.position);
				AudioSource.PlayClipAtPoint(ParentAudio.clip, transform.position);*/
            }
        }
    }
}
