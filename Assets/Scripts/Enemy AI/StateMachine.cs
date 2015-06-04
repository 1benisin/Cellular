using UnityEngine;
using System.Collections;

public class StateMachine<T>
{
	private T ownerObject;
	private State<T> currentState;

	public State<T> CurrentState {
		get {
			return currentState;
		}
		set {
			if (currentState != null) {
				currentState.OnDisable ();
			}

			currentState = value;

			if (currentState != null) {
				currentState.OnEnable (ownerObject, this);
			}
		}
	}

	public StateMachine (State<T> defaultState, T owner)
	{
		ownerObject = owner;
		CurrentState = defaultState;
	}

	public void Update ()
	{
		if (currentState != null) {
			currentState.CheckForNewState ();
			currentState.Update ();
		}
	}
}
