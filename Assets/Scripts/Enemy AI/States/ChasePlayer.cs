using UnityEngine;
using System.Collections;

public class ChasePlayer : State<Enemy> {

	public override void CheckForNewState() {
	
		float dist = Vector3.Distance(ownerObject.transform.position, ownerObject.target.position);
		if (dist > ownerObject.visualSpace) {
			ownerStateMachine.CurrentState = new PatrolPath();
		}
	}
	
	public override void Update() {

	}

	public override void OnEnable(Enemy owner, StateMachine<Enemy> newStateMachine) {
		
		base.OnEnable(owner, newStateMachine);

		owner.target = owner.Player.transform;
	}

}
