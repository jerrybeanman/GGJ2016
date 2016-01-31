using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoints : MonoBehaviour {
	public static SpawnPoints Instance { get; private set; }
	public List<LocationTracker> 	SpawnLocations;

	void Awake()
	{
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
		SpawnLocations = GetChilds();
	}

	public List<LocationTracker> GetChilds()
	{
		foreach(Transform child in transform)
			SpawnLocations.Add(child.gameObject.GetComponent<LocationTracker>());
		return SpawnLocations;
	}
}
