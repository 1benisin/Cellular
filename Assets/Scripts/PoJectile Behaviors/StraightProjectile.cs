using UnityEngine;
using System.Collections;

public class StraightProjectile : MonoBehaviour
{

	public float firingForce = 10;
	private Rigidbody2D body;

	void Start ()
	{
		body = GetComponent<Rigidbody2D> ();
		body.AddRelativeForce (new Vector2 (firingForce, 0), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
