using UnityEngine;
using System.Collections;

public class PatrolPath : State<Enemy>
{

	int nodeIndex = 0;

	public override void CheckForNewState ()
	{
		// check for exit conditions
	}
	
	public override void Update ()
	{
		if ((ownerObject.pathNodes [nodeIndex].position - ownerObject.transform.position).sqrMagnitude < 1) {
			nodeIndex++;

			if (nodeIndex >= ownerObject.pathNodes.Count) {
				nodeIndex = 0;
			}
			ownerObject.target = ownerObject.pathNodes [nodeIndex];
		}
	
	}

	public override void OnEnable (Enemy owner, StateMachine<Enemy> newStateMachine)
	{
		base.OnEnable (owner, newStateMachine);

		float closestDistance = float.MaxValue;

		for (int i = 0; i < owner.pathNodes.Count; i++) {
			float currentDistance = (owner.transform.position - owner.pathNodes [i].position).sqrMagnitude;

			if (currentDistance < closestDistance) {
				closestDistance = currentDistance;
				nodeIndex = i;
			}
		}

		ownerObject.target = owner.pathNodes [nodeIndex];
	}
}
