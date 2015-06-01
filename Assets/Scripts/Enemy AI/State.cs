using UnityEngine;
using System.Collections;

public abstract class State
{

	protected GameObject ownerObject;
	protected AI ai;

	public abstract void Update ();

	public virtual void OnEnable (GameObject owner, AI ownersBrain)
	{
		ownerObject = owner;
		ai = ownersBrain;
	}

	public virtual void OnDisable ()
	{

	}
}
