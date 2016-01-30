using UnityEngine;
using System.Collections;

public class HungerSystem : MonoBehaviour {
    public int Hunger = 100;
    public float TimeToStarve = 120;
    private float timeLeft;
    private int hunger;
    
	// Use this for initialization
	void Start () {
        timeLeft = TimeToStarve;
        hunger = Hunger;
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        hunger = Hunger - (int)((timeLeft / TimeToStarve) * Hunger);

        Debug.ClearDeveloperConsole();
        Debug.Log(hunger);

        if (timeLeft >= TimeToStarve)
        {
            Debug.Log("Game Over");
        }
    }

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
