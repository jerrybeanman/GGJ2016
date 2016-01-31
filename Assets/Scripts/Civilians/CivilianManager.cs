using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CivilianManager : MonoBehaviour {

	public static CivilianManager Instance { get; private set; }
	public List<Civilian> Civilian;	
	public int 		SpawnNumber;
	public int 		CivilianSpawnInterval;
	public float 	MaxPatrolSpeed;

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
		SpawnRandomCivilian();
	}

	public void SpawnRandomCivilian()
	{
		List<Route> RandomRoutes;
		Random random = new Random();
		Transform spawn_pos;
		int count = RoutesManager.Instance.Routes.Count;

		/* Selects random routes from RouteManager */
		RandomRoutes = RoutesManager.Instance.GetChilds()
						.OrderBy(x => Random.Range(0, count))
						.Take(SpawnNumber)
						.ToList();

		/* Initlaize new route values and spawn the civilian */
		foreach(Route route in RandomRoutes)
		{
			if(!route.Occupied)
			{
				/* Randomlly pick a civilian */
				Civilian tmp = Civilian [Random.Range (0, 2)];

				/* Mark the route as occupied */
				route.Occupied = true;

				/* Assign the random route the civilian will take*/
				tmp.route = route;

				/* Assign a random patrol speed to the civilian */
				tmp.PatrolSpeed = Random.Range (0, MaxPatrolSpeed);
				tmp.PauseDuration = Random.Range(0, 1f);

				/* Spawn position will be the first waypoint in the route */
				spawn_pos = route.Waypoints[0];

                /* Spawn civilian at destination as the child of this class */
                Civilian child = null;
                try
                {
                    child = Instantiate(tmp, spawn_pos.position, spawn_pos.rotation) as Civilian;
                    if (child != null)
                    {
                        child.transform.parent = transform;
                    } else
                    {
                        route.Occupied = false;
                    }
                } catch (System.Exception)
                {
                    if (child != null)
                        child.transform.parent = transform;
                    route.Occupied = false;
                }
				
                
			}
		}
	}
}
