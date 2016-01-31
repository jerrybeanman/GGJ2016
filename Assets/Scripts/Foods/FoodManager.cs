using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FoodManager : MonoBehaviour {
	public static FoodManager Instance { get; private set; }
	public List<Food> 		  FoodTypes;
	public int 			      SpawnNumber;
	public int 			      SpawnInterval;
	void Awake()
	{
		if (Instance != null) {
			DestroyImmediate(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	void Start () 
	{
		SpawnRandomFoods();
	}

	public void SpawnRandomFoods()
	{
		List<LocationTracker> RandomSpawnPoints;
		Random random = new Random();
		Transform spawn_pos;
		int count = SpawnPoints.Instance.SpawnLocations.Count;
		
		/* Selects random set of locations to spawn foods */
		RandomSpawnPoints = SpawnPoints.Instance.GetChilds()
			.OrderBy(x => Random.Range(0, count))
				.Take(SpawnNumber)
				.ToList();
		
		/* Initlaize new route values and spawn the civilian */
		foreach(LocationTracker location in RandomSpawnPoints)
		{
			if(!location.Occupied)
			{
				/* Mark the food as occupied */
				location.Occupied = true;

				/* Pick a random food */
				Food tmp = FoodTypes[Random.Range(0,2)];

				/* Spawn position will be the first waypoint in the route */
				spawn_pos = location.transform;
				
				/* Spawn the civilian at the first position in the route as child of this class */
				Food child = Instantiate(tmp, spawn_pos.position, spawn_pos.rotation) as Food;
				child.transform.parent = transform;
			}
		}
	}

}

