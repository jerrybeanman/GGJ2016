using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HungerSystem : MonoBehaviour {
    Collider2D other;

    void Update() {
    }

    // On collision with food, increase our time til we die by 10 seconds.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f ,0f);
            other.GetComponent<AudioSource>().UnPause();
			HealthBar.Instance.image.fillAmount -= (float)(other.gameObject.GetComponent<Food>().type+1) * 0.1f;
            this.other = other;
            StartCoroutine("Kill");
            
        }
    }

    IEnumerator Kill()
    {
        yield return new WaitForSeconds(.75f);
        Destroy(other.gameObject);
        yield return new WaitForSeconds(1);
    }
}
