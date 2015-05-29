using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{

	public float rotationSpeed = 2f;

	void FixedUpdate ()
	{
		transform.Rotate (new Vector3 (0, 0, rotationSpeed / 100));
	}
}
