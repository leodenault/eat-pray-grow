﻿using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	private const float speed = 0.05f;

	public GameObject monster;
	public Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// arrow key rotation control
		if (Input.GetKey (KeyCode.LeftArrow)) {
			monster.transform.rotation = Quaternion.Euler(0,0,90);
			cam.transform.Translate(new Vector3(-speed, 0, 0));
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			monster.transform.rotation = Quaternion.Euler(0,0,180);
			cam.transform.Translate(new Vector3(0,-speed,0));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			monster.transform.rotation = Quaternion.Euler(0,0,270);
			cam.transform.Translate(new Vector3(speed,0,0));
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			monster.transform.rotation = Quaternion.Euler(0,0,0);
			cam.transform.Translate(new Vector3(0,speed,0));
		}


	}
}
