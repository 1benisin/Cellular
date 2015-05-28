using UnityEngine;
using System.Collections;

public class PlayerRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		Debug.DrawLine (transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) , Color.magenta);
	}
}
