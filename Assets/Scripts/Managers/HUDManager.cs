using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

	public static HUDManager i;

	public Text WeaponPrefabGUI;
	public Text WeaponGUI;
	public Text EnergyGUI;
	public Text ProjectileGUI;

	void Start ()
	{
		// sets up singleton
		if (i == null) {
			i = this;
			DontDestroyOnLoad (gameObject);
		} else
			Destroy (this);
	}
	

	void Update ()
	{
		WeaponPrefabGUI.text = WeaponManager.i.curWeapon.prefabNum.ToString ();
		WeaponGUI.text = WeaponManager.i.curWeapon.shotType.ToString ();
		EnergyGUI.text = WeaponManager.i.curWeapon.energyType.ToString ();
		ProjectileGUI.text = WeaponManager.i.curWeapon.projectileType.ToString ();
	}
}
