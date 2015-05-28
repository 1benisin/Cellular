using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float engineForce;
	private Rigidbody2D physicsBody;
	
	void Start()
	{
		physicsBody = GetComponent<Rigidbody2D> ();
	}
	
	void Update()
	{
		float xAxis = Input.GetAxisRaw ("Horizontal") * engineForce;
		float yAxis = Input.GetAxisRaw ("Vertical") * engineForce;

		physicsBody.AddForce (new Vector2(xAxis, yAxis));
	}
}
