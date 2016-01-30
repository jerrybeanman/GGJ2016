using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HungerSystem : MonoBehaviour {

    // On collision with food, increase our time til we die by 10 seconds.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
			Image image = HealthBar.Instance.image;
			HealthBar.Instance.image.fillAmount -= 0.2f;
			Destroy(other.gameObject);
        }
    }
}
