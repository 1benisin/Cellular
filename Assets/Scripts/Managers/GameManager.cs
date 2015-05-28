using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager i = null; // singleton instance

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
