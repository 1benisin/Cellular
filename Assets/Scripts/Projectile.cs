using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	protected Vector2 originationPoint;
	protected Vector2 target;
	protected Vector2 direction;
	protected float velocity;

	private EnergyType energyType;
	private ProjectileType behaviour;

//	public void Projectile (EnergyType energyType); 

	void Start () {
		energyType = WeaponManager.i.curWeapon.energyType;
		behaviour = WeaponManager.i.curWeapon.projectileType;

		switch (behaviour) {
		case ProjectileType.Straight:
			GetComponent<ProjectileBehavior_Straight>().enabled = true;
			break;
		case ProjectileType.Seekeer:
			Debug.Log("Projectile behaviour is null");
			break;
		case ProjectileType.ProximityMine:
			Debug.Log("Projectile behaviour is null");
			break;
		default:
			Debug.Log("Projectile behaviour is null");
			break;
		}
	}

}
