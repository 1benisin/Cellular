using UnityEngine;
using System.Collections;
using Pathfinding;

public class PathfindingAI {
	private Enemy enemy; // cache
	private Seeker seeker;

	private Path path;
	private int currentWaypoint;
	private bool pathIsEnded = false;
	private Vector3 lastTargetPosition = Vector3.one; // position of target on last UpdatePath() call
	private float toleranceForTargetMovement = .5f; // how much the target has to move before Updating path


	public PathfindingAI(Enemy e) {
		if (e == null) 
			Debug.LogWarning("Enemy is null");
		else
			Debug.Log("Pathfinder: instatiated with enemy instace");
		enemy = e;
		seeker = enemy.GetComponent<Seeker>();

	}
	 
	public void UpdatePath() {
		if (TargetHasMoved()) {

			lastTargetPosition = enemy.target.position;
			seeker.StartPath(enemy.transform.position, enemy.target.position, OnPathComplete);
		}
	} 
	bool TargetHasMoved() {
		float dist = Vector3.Distance(enemy.target.position, lastTargetPosition);
		if (dist >= toleranceForTargetMovement)
			return true;
		else 
			return false;
	}
	
	void OnPathComplete(Path p) {
//		Debug.Log("We got a path. Did it have an error?" + p.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}
	
	public Vector3 GetDirection() {

		if (enemy.target == null)  // check
			return Vector3.zero;
			
		if (path == null)  // check
			return Vector3.zero;

		// if reached last waypoint, path is ended
		if (currentWaypoint >= path.vectorPath.Count) { 
			if (pathIsEnded)
				return Vector3.zero;
				
			Debug.Log("End of path reached");
			pathIsEnded = true;
			return Vector3.zero;
		}
			
		pathIsEnded = false;
			
		// direction to the next waypoint
		Vector3 dir = (path.vectorPath [currentWaypoint] - enemy.transform.position).normalized;

		// increment to next waypoint if close enough to current waypoint
		float dist = Vector3.Distance(enemy.transform.position, path.vectorPath [currentWaypoint]);
		if (dist <= enemy.personalSpace)
			currentWaypoint++;

		return dir;
          
	}
}
