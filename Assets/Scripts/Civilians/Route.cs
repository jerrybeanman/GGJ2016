using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Route : MonoBehaviour {

	public List<Transform> Waypoints;
	void Awake()
	{
		foreach(Transform child in transform)
			Waypoints.Add(child);
	}
}
