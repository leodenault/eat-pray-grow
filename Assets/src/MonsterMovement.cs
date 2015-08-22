using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	private const float speed = 1.8f;
	public float rotationDegreesPerSecond = 10f;

	public GameObject monster;
	public Camera cam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// arrow key rotation control
		float distance = Time.deltaTime * speed;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			float currentAngle = monster.transform.rotation.eulerAngles.z;
			if(Mathf.Abs(90-currentAngle) <= 5){
				monster.transform.rotation = Quaternion.Euler(0,0,90);
			} else if(currentAngle > 90 && currentAngle < 270){
				RotateCWise();
			} else {
				RotateCountCWise();
			}
			cam.transform.Translate(new Vector3(-distance, 0, 0));
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			float currentAngle = monster.transform.rotation.eulerAngles.z;
			if(Mathf.Abs(180-currentAngle) <= 5){
				monster.transform.rotation = Quaternion.Euler(0,0,180);
			} else if(currentAngle >= 0 && currentAngle < 180){
				RotateCountCWise();
			} else {
				RotateCWise();
			}
			cam.transform.Translate(new Vector3(0,-distance,0));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			float currentAngle = monster.transform.rotation.eulerAngles.z;
			if(Mathf.Abs(270-currentAngle) <= 5){
				monster.transform.rotation = Quaternion.Euler(0,0,270);
			} else if(currentAngle < 270 && currentAngle > 90){
				RotateCountCWise();
			} else {
				RotateCWise();
			}
			cam.transform.Translate(new Vector3(distance,0,0));
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			float currentAngle = monster.transform.rotation.eulerAngles.z;
			if(Mathf.Abs(0-currentAngle) <= 5){
				monster.transform.rotation = Quaternion.Euler(0,0,0);
			} else if(currentAngle > 0 && currentAngle <= 180){
				RotateCWise();
			} else {
				RotateCountCWise();
			}
			cam.transform.Translate(new Vector3(0,distance,0));
		}


	}

	void RotateCountCWise(){
		float currentAngle = monster.transform.rotation.eulerAngles.z;
		float newAngle = currentAngle + rotationDegreesPerSecond;
		monster.transform.rotation = Quaternion.Euler (0, 0, newAngle);
	}

	void RotateCWise(){
		float currentAngle = monster.transform.rotation.eulerAngles.z;
		float newAngle = currentAngle - rotationDegreesPerSecond;
		monster.transform.rotation = Quaternion.Euler (0, 0, newAngle);
	}

}
