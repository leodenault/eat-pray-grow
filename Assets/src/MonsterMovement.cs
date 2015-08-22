using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	public GameObject monster;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// arrow key rotation control
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			monster.transform.rotation = Quaternion.Euler(0,0,90);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			monster.transform.rotation = Quaternion.Euler(0,0,180);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			monster.transform.rotation = Quaternion.Euler(0,0,270);
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			monster.transform.rotation = Quaternion.Euler(0,0,0);
		}

	}
}
