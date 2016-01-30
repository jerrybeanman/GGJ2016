using UnityEngine;
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
    
	// Use this for initialization
	void Start () {
        timeLeft = TimeToStarve;
        hunger = Hunger;
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
            Destroy(other.gameObject);
            if (timeLeft + 10 <= TimeToStarve)
                timeLeft += 10;
            else
                timeLeft = TimeToStarve;
        }
    }
}
