using UnityEngine;
using System.Collections;

public class ProjectileBehavior_Straight : MonoBehaviour {

	public float firingForce = 5;
	private Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D> ();
		body.AddRelativeForce(new Vector2(firingForce, 0), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
