using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float damage = 1.0f;
	public int maxAmmo = 0; 		// 0 for infinit ammo
	public float fireDelay = 1.0f;
	public LayerMask layerMask = -1;
	public bool automaticFire = false;

	private bool readyToFire = true;

	void FirePrimary () {
		GameObject curProj = WeaponManager.i.GetCurrentProjectile ();
		Instantiate(curProj, transform.position, transform.rotation);

	}


	void Update () {
		CheckInput ();
	}

	void CheckInput(){

					// set up automatic weapon funtionality
		bool primaryFirePressed;

		if (automaticFire)
			primaryFirePressed = Input.GetMouseButton (0);
		else
			primaryFirePressed = Input.GetMouseButtonDown (0);

					// fire if ready
		if (primaryFirePressed && readyToFire) {
			FirePrimary();
			readyToFire = false;
					// delay before setting ready to fire again
			Invoke("SetReadyToFire", fireDelay);
		}
	}

	void SetReadyToFire(){
		readyToFire = true;
	}
}
