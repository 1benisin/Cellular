using UnityEngine;
using System.Collections;
using Pathfinding;

public class TestUpdatePathfindingGraph : MonoBehaviour
{
	public GraphUpdateScene pathfindingGraphUpdater;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{

		//TODO: do not tell the pathfinding graph to update this objects position every Update();
		pathfindingGraphUpdater.Apply ();
	}
}
