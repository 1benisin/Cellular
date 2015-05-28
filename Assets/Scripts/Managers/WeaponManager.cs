using UnityEngine;
using System.Collections;

public enum EnergyType
{
	Kinetic,
	Ballistic,
	Laser,
	Ice,
	Electric,
	Chemical,
	NumberOfTypes
}
;

public enum ShotType
{
	Single,
	Dual,
	Cluster,
	Rear,
	NumberOfTypes
}
;

public enum ProjectileType
{
	Straight,
	Seekeer,
	ProximityMine,
	NumberOfTypes
}
;



public class WeaponManager : MonoBehaviour
{
				
	public static WeaponManager i = null;		// singleton instance

	public GameObject kineticProjectile;
	public GameObject ballisticProjectile;
	public GameObject iceProjectile;
	public GameObject laserProjectile;
	public GameObject chemicalProjectile;
	public GameObject electricProjectile;

	public WeaponPrefab curWeapon;
	public struct WeaponPrefab
	{

		public int prefabNum;
		public ShotType shotType;
		public EnergyType energyType;
		public ProjectileType projectileType;

		public WeaponPrefab (int i, ShotType s, EnergyType e, ProjectileType p)
		{

			prefabNum = i;
			shotType = s;
			energyType = e;
			projectileType = p;
		}
	}

	
	private WeaponPrefab prefab1;
	private WeaponPrefab prefab2;
	private WeaponPrefab prefab3;
	private KeyCode keyForShotType;
	private KeyCode keyForEnergyType;
	private KeyCode keyForProjectileType;
	private KeyCode keyForPrefab1;
	private KeyCode keyForPrefab2;
	private KeyCode keyForPrefab3;


	void Start ()
	{
		
		// sets up singleton
		if (i == null) {
			i = this;
			DontDestroyOnLoad (gameObject);
		} else
			Destroy (this);

		InitializePrefabs ();
		InitializeKeyCodes ();
	}
	
	
	void InitializePrefabs ()
	{
		
		prefab1 = new WeaponPrefab (1, ShotType.Single, EnergyType.Kinetic, ProjectileType.Straight);
		prefab2 = new WeaponPrefab (2, ShotType.Single, EnergyType.Kinetic, ProjectileType.Straight);
		prefab3 = new WeaponPrefab (3, ShotType.Single, EnergyType.Kinetic, ProjectileType.Straight);
		curWeapon = prefab1;
		Debug.Log (curWeapon);
	}

	void InitializeKeyCodes ()
	{
		keyForShotType = KeyCode.J;
		keyForEnergyType = KeyCode.K;
		keyForProjectileType = KeyCode.L;
		keyForPrefab1 = KeyCode.Alpha1;
		keyForPrefab2 = KeyCode.Alpha2;
		keyForPrefab3 = KeyCode.Alpha3;
	}



	void Update ()
	{

		CheckForPrefabChange ();
		CheckForWeaponTypeChanges ();
	}

	void CheckForWeaponTypeChanges ()
	{
		// check for prefab 1 changes
		if (Input.GetKey (keyForPrefab1)) { 
			// cycle shot types on keypress
			if (Input.GetKeyDown (keyForShotType)) {
				prefab1.shotType += 1;
				if (prefab1.shotType == ShotType.NumberOfTypes)
					prefab1.shotType = 0;
			}
			if (Input.GetKeyDown (keyForEnergyType)) {
				prefab1.energyType += 1;
				if (prefab1.energyType == EnergyType.NumberOfTypes)
					prefab1.energyType = 0;
			}
			if (Input.GetKeyDown (keyForProjectileType)) {
				prefab1.projectileType += 1;
				if (prefab1.projectileType == ProjectileType.NumberOfTypes)
					prefab1.projectileType = 0;
			}
			curWeapon = prefab1;
		}
		// check for prefab 2 changes
		if (Input.GetKey (keyForPrefab2)) { 
			// cycle shot types on keypress
			if (Input.GetKeyDown (keyForShotType)) {
				prefab2.shotType += 1;
				if (prefab2.shotType == ShotType.NumberOfTypes)
					prefab2.shotType = 0;
			}
			if (Input.GetKeyDown (keyForEnergyType)) {
				prefab2.energyType += 1;
				if (prefab2.energyType == EnergyType.NumberOfTypes)
					prefab2.energyType = 0;
			}
			if (Input.GetKeyDown (keyForProjectileType)) {
				prefab2.projectileType += 1;
				if (prefab2.projectileType == ProjectileType.NumberOfTypes)
					prefab2.projectileType = 0;
			}
			curWeapon = prefab2;
		}
		// check for prefab 1 changes
		if (Input.GetKey (keyForPrefab3)) { 
			// cycle shot types on keypress
			if (Input.GetKeyDown (keyForShotType)) {
				prefab3.shotType += 1;
				if (prefab3.shotType == ShotType.NumberOfTypes)
					prefab3.shotType = 0;
			}
			if (Input.GetKeyDown (keyForEnergyType)) {
				prefab3.energyType += 1;
				if (prefab3.energyType == EnergyType.NumberOfTypes)
					prefab3.energyType = 0;
			}
			if (Input.GetKeyDown (keyForProjectileType)) {
				prefab3.projectileType += 1;
				if (prefab3.projectileType == ProjectileType.NumberOfTypes)
					prefab3.projectileType = 0;
			}
			curWeapon = prefab3;
		}


	}

	void CheckForPrefabChange ()
	{

		if (Input.GetKeyDown (keyForPrefab1))
			curWeapon = prefab1;

		if (Input.GetKeyDown (keyForPrefab2))
			curWeapon = prefab2;

		if (Input.GetKeyDown (keyForPrefab3))
			curWeapon = prefab3;
	}

	public GameObject GetCurrentProjectile ()
	{

		switch (curWeapon.energyType) {
		case EnergyType.Kinetic:
			return kineticProjectile;
		case EnergyType.Ballistic:
			return ballisticProjectile;
		case EnergyType.Ice:
			return iceProjectile;
		case EnergyType.Laser:
			return laserProjectile;
		case EnergyType.Chemical:
			return chemicalProjectile;
		case EnergyType.Electric:
			return electricProjectile;
		default:
			Debug.LogError ("Switch Case Broken");
			return null;
		}

	}
	
}












