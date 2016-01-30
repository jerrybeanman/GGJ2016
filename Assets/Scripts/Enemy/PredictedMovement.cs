using UnityEngine;
using System.Collections;

public class PredictedMovement : MonoBehaviour 
{
	/* Number of waypoints */
	public Transform[] 	Waypoints;
	/* The walking speed */
	public float 		PatrolSpeed;
	/* Keep repeating the between the waypoints*/
	public bool 		Loop;
	/* How long does it take to turn */
	public float		DampingLook;
	/* How long to pause at a waypoint */
	public float 		PauseDuration;

	private float 				_CurTime;
	private int 				_CurrentWaypoint;
	private CharacterController _Character;

	void Start()
	{
		_Character = GetComponent<CharacterController>();
	}

	void Update()
	{
		if(_CurrentWaypoint < Waypoints.Length)
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
			/*rotation = Quaternion.LookRotation(target - transform.position);
			rotation.x = 0;
			rotation.y = 0;*/
			float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.Rotate ((Vector3.forward * -120));

			/*transform.rotation = Quaternion.Slerp(transform.rotation, 
			                                      rotation, 
			                                      Time.deltaTime * DampingLook);*/
			_Character.Move(move_direction.normalized * PatrolSpeed * Time.deltaTime);
		}
	}
}
