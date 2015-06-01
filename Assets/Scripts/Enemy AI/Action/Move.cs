using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]

public class Move : MonoBehaviour
{
	// what to chase
	public Transform target;
	// how many times per second we will update our path
	public float updateRate;

	// Cache
	private Seeker seeker;
	private Rigidbody2D rb;

	// the calculated path
	public Path path;

	// the AI's speed per second
	public float speed = 300f;
	public ForceMode2D fMode;

	[HideInInspector]
	public bool
		pathIsEnded = false;

	// the distance to current waypoint that is close enough to move on to next waypoint
	public float closeEnoughDistance = 3;

	// the waypoint we are moving toward
	private int currentWaypoint;


	void Start ()
	{
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D> ();

		if (target == null)
			Debug.Log ("No target found");

		// Start a new path to the target position and return results to OnPathComplete method
		seeker.StartPath (transform.position, target.position, onPathComplete);

		StartCoroutine (UpdatePath ());
	}

	IEnumerator UpdatePath ()
	{
		if (target == null) {
			return false;
		}
		// find a new target if target has disappeared / been destroyed


		// Start a new path to the target position and return results to OnPathComplete method
		seeker.StartPath (transform.position, target.position, onPathComplete);

		yield return new WaitForSeconds (1f / updateRate);
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

	void FixedUpdate ()
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

		dir *= speed * Time.fixedDeltaTime;

		rb.AddForce (dir, fMode);

		float dist = Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]);
		if (dist < closeEnoughDistance) {
			currentWaypoint++;
			return;
		}
	}
}









