using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager i;

	void Start () {
		// sets up singleton
		if(i == null) {
			i = this;
			DontDestroyOnLoad(gameObject);
		}
		else Destroy(this);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
