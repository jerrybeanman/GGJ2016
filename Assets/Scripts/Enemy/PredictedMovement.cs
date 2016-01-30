using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PredictedMovement : MonoBehaviour 
{
	public Route 	route;
	/* The walking speed */
	public float 		PatrolSpeed;
	/* Keep repeating the between the waypoints*/
	public bool 		Loop;
	/* How long does it take to turn */
	public float		DampingLook;
	/* How long to pause at a waypoint */
	public float 		PauseDuration;

	/* Number of waypoints */
	private List<Transform> 	Waypoints;
	private float 				_CurTime;
	private int 				_CurrentWaypoint;
	private CharacterController _Character;

	void Start()
	{
		Waypoints = route.Waypoints;
		_Character = GetComponent<CharacterController>();
	}

	void Update()
	{
		if(_CurrentWaypoint < Waypoints.Count)
		{
			Patrol();
		}else
		/* For looping between waypoints */
		if(Loop)
		{
			_CurrentWaypoint = 0;
		}
	}

	private void Patrol()
	{
		Vector3 target = Waypoints[_CurrentWaypoint].position;
		Vector3 move_direction = target - transform.position;
		//Quaternion rotation;
		/* the square root of (x*x + y*y). If we have reached target */
		if(move_direction.magnitude < 0.5)
		{
			if(_CurTime == 0)
				/* pause at the waypoint */
				_CurTime = Time.time;

			/* If we have timeout on pausing */
			if((Time.time - _CurTime) >= PauseDuration)
			{
				/* move onto the next waypoint */
				_CurrentWaypoint++;
				_CurTime = 0;
			}
		}
		/* Rotate and move the character to that position */
		else
		{
			/* Rotate towards target*/
			float angle = Mathf.Atan2(move_direction.y, move_direction.x) * Mathf.Rad2Deg;
			Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * DampingLook);

			/* Smooth movement towards the target */
			_Character.Move(move_direction.normalized * PatrolSpeed * Time.deltaTime);
		}
	}
}
