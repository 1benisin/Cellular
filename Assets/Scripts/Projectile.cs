using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

	private Vector2 originationPoint; // position at START
	private Vector2 target; 			// mouse pointer
	private EnergyType energyType;
	private ProjectileType behaviour;

	//	public void Projectile (EnergyType energyType); 

	void Start ()
	{
//		energyType = WeaponManager.i.curWeapon.energyType;
		behaviour = WeaponManager.i.curWeapon.projectileType;

		TurnOnBehaviorScript ();

	}

	void TurnOnBehaviorScript () // turn on proper behavior script attached to this game object
	{
		switch (behaviour) {
		case ProjectileType.Straight:
			GetComponent<StraightProjectile> ().enabled = true;
			break;
		case ProjectileType.Seekeer:
			Debug.Log ("Projectile behaviour is null");
			break;
		case ProjectileType.ProximityMine:
			Debug.Log ("Projectile behaviour is null");
			break;
		default:
			Debug.Log ("Projectile behaviour is null");
			break;
		}  
	}

}
