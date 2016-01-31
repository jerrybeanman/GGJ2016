using UnityEngine;
using System.Collections;

public enum FoodTypes
{
	apple,
	bread,
	ham
};

public class Food : MonoBehaviour 
{	
	public FoodTypes type;

    void Start()
    {
        var audio = GetComponent<AudioSource>();
        audio.Pause();
    }
}
