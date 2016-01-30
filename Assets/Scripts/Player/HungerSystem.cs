using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HungerSystem : MonoBehaviour {
    //Maximum hunger points
    public int Hunger = 100;
    //Amount of time in seconds until hunger would reach zero
    public float TimeToStarve = 120;
    //Local amount of time til we starve
    private float timeLeft;
    //Local amount of hunger, this is the actual amount.
    private int hunger;

	public Image image;
    
	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
	}
	
	// Every frame updates hunger & time left
	void Update () {
        timeLeft -= Time.deltaTime;
        hunger = Hunger - (int)((timeLeft / TimeToStarve) * Hunger);

        if (timeLeft >= TimeToStarve)
        {
			
            Debug.Log("Game Over");
        }
    }

    // On collision with food, increase our time til we die by 10 seconds.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Food")
        {
			image.fillAmount -= 0.2f;
        }
    }
}
