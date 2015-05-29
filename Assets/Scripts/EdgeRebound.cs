using UnityEngine;
using System.Collections;

public class EdgeRebound : MonoBehaviour
{

	public float bounciness = 2f;

//	void OnTriggerExit2D(Collider2D other) 
//	{
//		Rigidbody2D otherBody = other.attachedRigidbody;
////		otherBody.velocity = Vector2.zero;
//		Vector2 oppositeVelocity = otherBody.position.normalized * -otherBody.velocity.magnitude * bounciness;
//		otherBody.AddForce (oppositeVelocity, ForceMode2D.Impulse);
//	}
}
