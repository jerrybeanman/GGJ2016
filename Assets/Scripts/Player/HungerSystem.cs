using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HungerSystem : MonoBehaviour {

    // On collision with food, increase our time til we die by 10 seconds.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
			HealthBar.Instance.image.fillAmount -= (float)(other.gameObject.GetComponent<Food>().type+1) * 0.1f;
			Destroy(other.gameObject);
        }
    }
}
