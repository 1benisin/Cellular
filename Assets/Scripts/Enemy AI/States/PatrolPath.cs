using UnityEngine;
using System.Collections;

public class PatrolPath : State<Enemy> {

	int nodeIndex = 0;

	public override void CheckForNewState() {
	
		float dist = Vector3.Distance(ownerObject.transform.position, ownerObject.Player.transform.position);
		if (dist < ownerObject.visualSpace) {
			ownerStateMachine.CurrentState = new ChasePlayer();
		}
	}
	
	public override void Update() {
	
		float dist = Vector3.Distance(ownerObject.pathNodes [nodeIndex].position, ownerObject.transform.position);

		if (dist < ownerObject.personalSpace) {
			nodeIndex++;

			if (nodeIndex >= ownerObject.pathNodes.Count) {
				nodeIndex = 0;
			}
			ownerObject.target = ownerObject.pathNodes [nodeIndex];
		}
	
	}

	public override void OnEnable(Enemy owner, StateMachine<Enemy> newStateMachine) {
		base.OnEnable(owner, newStateMachine);

		// check
		if (owner.pathNodes.Count < 1) {
			Debug.LogError("Enemy cannot enter PatrolPath state without nodes in pathNodes[]");
		}

		//find closest pathnode
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
