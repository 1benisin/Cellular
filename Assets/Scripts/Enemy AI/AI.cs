using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TagFrenzy;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]

public class AI : MonoBehaviour
{
	#region Variables
	// Cache
	[HideInInspector]
	public Seeker
		seeker;
	[HideInInspector]
	public Rigidbody2D
		rb;

	// radius of different zones around objext
	public float personalSpace;
	public float visualSpace;
	public float attackSpace;

	// the AI's speed per second
	public float Urgency = 300f;
	public ForceMode2D fMode;

	// point to move to
	public Transform target;
	// point to look & shoot at
	protected Transform pointOfInterest;

	// the calculated path
	private Path path;
	// how many times per second we will update our path
	private float updatePathRate = 1;
	// when end of path is reached
	private bool pathIsEnded = false;
	// the distance to current waypoint that is close enough to move on to next waypoint
	private float closeEnoughToWaypoint = 3;
	// the waypoint we are moving toward
	private int currentWaypoint;
	// current behavior state
	private State currentState;
	public State CurrentState {  
		get {
			return currentState;
		}
		set {
			if (currentState != null)
				currentState.OnDisable ();
			
			currentState = value;
			
			if (currentState == null)
				Debug.Log ("No state passed in");
			else
				currentState.OnEnable (gameObject, this);
		}
	} // currentState accessors
	#endregion


	void Start ()
	{
		// caching
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D> ();

		if (target == null)
			Debug.Log ("No target found");

		// Start a new path to the target position and return results to OnPathComplete method
		seeker.StartPath (transform.position, target.position, onPathComplete);

		StartCoroutine (UpdatePath ());

		//TODO remove: this is a test
		GameObject closestObj = ClosestObjectWithTag (Tags.Obstacle);
		closestObj.GetComponent<SpriteRenderer> ().color = Color.red;
		// remove^
	}


	void FixedUpdate ()
	{
		MoveToTarget ();
	}


	IEnumerator UpdatePath ()
	{
		if (target == null) {
			return false;
		}
		// find a new target if target has disappeared / been destroyed


		// Start a new path to the target position and return results to OnPathComplete method
		seeker.StartPath (transform.position, target.position, onPathComplete);

		yield return new WaitForSeconds (1f / updatePathRate);
		StartCoroutine (UpdatePath ());
	}


	void onPathComplete (Path p)
	{
		Debug.Log ("We got a path. Did it have an error?" + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}


	#region Requests to AI

//	Vector3 NearestHidingSpot ()
//	{
//		// find nearst obstacle TODO
//		Vector2 curPos = new Vector2 (transform.position.x, transform.position.y);
//		Collider2D[] surroundingObjects = Physics2D.OverlapCircleAll (curPos, visualSpace.radius);
//
//		// find direction away from player
//		// find point in direction that leaves enough room for personal space
//	}

	GameObject ClosestObjectWithTag (Tags t)
	{

		// get all Gameobjects with that tag using TagFrenzy's Multitag class method
		List<GameObject> ObjList = MultiTag.FindGameObjectsWithTags (t);

		if (ObjList.Count < 1) {
			Debug.Log ("list is empty");
			return null;
		}
		
		GameObject closestObject = null;
		float closestDistance = float.PositiveInfinity;

		// loop through list and find closest object
		foreach (GameObject obj in ObjList) {
			if (closestObject == null) {
				closestObject = obj;
				closestDistance = (obj.transform.position - transform.position).sqrMagnitude;
			}

			float distace = (obj.transform.position - transform.position).sqrMagnitude;

			if (distace < closestDistance) {
				closestDistance = distace;
				closestObject = obj;
			}
		}
		return closestObject;
	} // takes a TagFrenzy Tag class object

	#endregion

	#region Subconcious Actions

	void MoveToTarget ()
	{
		if (target == null) {
			Debug.Log ("No target found");
			return;
		}
		
		if (path == null)
			return;
		
		if (currentWaypoint >= path.vectorPath.Count) {
			if (pathIsEnded)
				return;
			
			Debug.Log ("End of path reached");
			pathIsEnded = true;
			return;
		}
		
		pathIsEnded = false;
		
		// direction to the next waypoint
		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
		
		dir *= Urgency * Time.fixedDeltaTime;
		
		rb.AddForce (dir, fMode);
		
		float dist = Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]);
		if (dist < closeEnoughToWaypoint) {
			currentWaypoint++;
			return;
		}
	}

	void TakeDamage ()
	{

	}

	#endregion
}









