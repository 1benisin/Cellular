using UnityEngine;
using System.Collections;
using Pathfinding;

public class GraphUpdater : MonoBehaviour
{

	public float secondsBetweenUpdates = 2; // times / sec the grid will be updated
	public GameObject updateInsideBounds;

	private Bounds bounds;

//	ProceduralGridMover gridMover;

	// Use this for initialization
	void Start ()
	{
		// gets the level bounds
		if (updateInsideBounds == null)
			Debug.Log ("Add LevelCell object to GraphUpdater for A*");
		bounds = updateInsideBounds.GetComponent<Renderer> ().bounds;
		StartCoroutine (UpdateGraph ());
	}
	
	IEnumerator UpdateGraph ()
	{
		// update graph inside level bounds every set amount of seconds
		AstarPath.active.UpdateGraphs (bounds);
		yield return new WaitForSeconds (secondsBetweenUpdates);
		StartCoroutine (UpdateGraph ());
	}

}
