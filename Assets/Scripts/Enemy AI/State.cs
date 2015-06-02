using UnityEngine;
using System.Collections;

public abstract class State
{

	protected GameObject ownerObject;
	protected AI ai;
	public float updateDelay = 1f;

	public abstract void UpdateState ();
	public abstract void ExitTriggersCheck ();

	public virtual void WhenMadeCurrentState (GameObject owner, AI ownerAi)
	{
		ownerObject = owner;
		ai = ownerAi;
	}

	public virtual void OnDisable ()
	{

	}
}
