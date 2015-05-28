using UnityEngine;
using System.Collections;

public class FireBullet : MonoBehaviour {

	public GameObject bulletPrefab;
	public float firePower = 10;
	public float fireRate = 1;

	private bool firing = false;


	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Fire ();
	
	}

	void Fire ()
	{

		if (Input.GetMouseButton (0) && !firing) {
			firing = true;
			GameObject bullet = GameObject.Instantiate (bulletPrefab, transform.position, transform.rotation) as GameObject;
			Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D> ();
			bulletBody.AddRelativeForce(new Vector2(firePower, 0), ForceMode2D.Impulse);

			Invoke("ReadyToFire", fireRate);

		}
	}

	void ReadyToFire()
	{
		firing = false;
	}
}
