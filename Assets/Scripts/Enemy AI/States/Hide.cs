using UnityEngine;
using System.Collections;

public class Hide : OutdatedState
{

	public override void UpdateState ()
	{
		ai.pathfindingTarget = ai.NearestHidingSpot ();
		ExitTriggersCheck ();
	}

	public override void ExitTriggersCheck ()
	{
//		if (ai.IsPointInsideVisualSpace (ai.player.transform.position))
//			ai.SetToDefaultState ();

	}
}
