using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CivilianManager : MonoBehaviour {

	public Civilian Civilian;	
	public int 		SpawnNumber;
	public float 	MaxPatrolSpeed;
	void Start () 
	{
		SpawnRandomCivilian();
	}

	void SpawnRandomCivilian()
	{
		List<Route> RandomRoutes;
		Random random = new Random();
		int count = RoutesManager.Instance.Routes.Count;

		/* Selects random routes from RouteManager */
		RandomRoutes = RoutesManager.Instance.Routes
						.OrderBy(x => Random.Range(0, count))
						.Take(SpawnNumber)
						.ToList();

		foreach(Route route in RandomRoutes)
		{
			Transform spawn_pos = route.Waypoints[0];

			/* Assign the random route the civilian will take*/
			Civilian.route = route;

			/* Assign a random patrol speed to the civilian */
			Civilian.PatrolSpeed = Random.Range (0, MaxPatrolSpeed);

			/* Spawn the civilian at the first position in the route */
			Instantiate(Civilian, spawn_pos.position, spawn_pos.rotation);
		}
	}
}
