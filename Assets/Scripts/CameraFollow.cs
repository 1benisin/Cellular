using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public Transform target;
	public float followSpeed;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targetPosition = new Vector3 (target.position.x, target.position.y, -1);
		transform.position = targetPosition;

	}
}
