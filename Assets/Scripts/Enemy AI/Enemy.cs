using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

[RequireComponent (typeof(Collider2D), typeof(Rigidbody2D), typeof(Seeker))]

public class Enemy : MonoBehaviour {

	#region Variables
	private Rigidbody2D rb;
	private PathfindingAI pathfinder;
	private StateMachine<Enemy> stateMachine;
	[HideInInspector]
	private Player
		player;
	public Player Player {
		get {
			if (player == null) {
				Debug.LogWarning("Player does not exist");
				return null;
			}
			return player;
			} 
		private set {
			player = value;
			}
	}

//      private Seeker seeker;                    // pathfinding agent
	public Transform target;                  // target object
//      public float targetChangeTolerance = 1f;  // how far target has to move before we recaculate a path to him
//      public Vector3 targetPosition;            // last known target position
	private float updatePathRate = 2f;
//	private Path path;
//	private int currentWaypoint;
//      private float waypointDistanceTolerace = 3f;
//	private bool pathIsEnded = false;
	public float speed = 10f;
	public ForceMode2D fMode = ForceMode2D.Impulse;

	public List<Transform> pathNodes = new List<Transform>();		// patrol path objects

	public float personalSpace = 2f;	// distance enemy wants empty around him
	public float visualSpace = 10f;		// distance enemy can see
	public float attackSpace = 12f;		// distace enemy can attack

	private Vector3 lookTarget;		// point to look at
//      private Vector3 moveInput;
//      private float turnAmount;			// rotation amount per frame tolerance
//      private Vector3 velocity;
	#endregion
	
	#region System
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, attackSpace);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, visualSpace);
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(transform.position, personalSpace);
		
	}

	void Start() {
		// caching
		pathfinder = new PathfindingAI(this);
		rb = GetComponent<Rigidbody2D>();
		stateMachine = new StateMachine<Enemy>(new PatrolPath(), this);
		Player = Object.FindObjectOfType<Player>();

		// start pathfinding
		StartCoroutine(UpdatePath()); 
	}

	void Update() {
		stateMachine.Update();
	}

	void FixedUpdate() {
		// move enemy along path
		Vector3 dir = pathfinder.GetDirection(); 

		if (dir != Vector3.zero) {

			dir *= (speed * Time.fixedDeltaTime);
		
			rb.AddForce(dir, fMode);
		}

//		MoveToTarget ();
	}

	IEnumerator UpdatePath() {
		// check
		if (target == null) {
			Debug.Log("No target found. Don't move");
			return false;
		}
		if (pathfinder == null) {
			Debug.LogError("PathfinderAI missing");
		}
		

		pathfinder.UpdatePath();

		// wait then update path 
		yield return new WaitForSeconds(1f / updatePathRate);
		StartCoroutine(UpdatePath());
	}


	#endregion

	#region Movement
//	IEnumerator UpdatePath ()
//	{
//		// check
//		if (target == null) {
//			Debug.Log ("No target found. Don't move");
//			return false;
//		}
//
//		// find a path to target and pass it to OnPathComplete method
//		seeker.StartPath (transform.position, target.position, OnPathComplete);
//
//		// wait then update path 
//		yield return new WaitForSeconds (1f / updatePathRate);
//		StartCoroutine (UpdatePath ());
//
//	}
//	
//	
//	void OnPathComplete (Path p)
//	{
//		Debug.Log ("We got a path. Did it have an error?" + p.error);
//		if (!p.error) {
//			path = p;
//			currentWaypoint = 0;
//		}
//	}
//
//	void MoveToTarget ()
//	{
//		// check
//		if (target == null) {
//			Debug.Log ("No target found. Don't move");
//			return;
//		}
//
//		// check
//		if (path == null)
//			return;
//
//		// check if reached end of path
//		if (currentWaypoint >= path.vectorPath.Count) {
//			if (pathIsEnded)
//				return;
//			
//			Debug.Log ("End of path reached");
//			pathIsEnded = true;
//			return;
//		}
//		
//		pathIsEnded = false;
//		
//		// direction to the next waypoint
//		Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
//		
//		dir *= speed * Time.fixedDeltaTime;
//		
//		rb.AddForce (dir, fMode);
//		
//		float dist = Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]);
//		if (dist < waypointDistanceTolerace) {
//			currentWaypoint++;
//			return;
//		}
//	}
	#endregion
}
