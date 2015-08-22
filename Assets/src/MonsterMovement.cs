using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	private const float speed = 1.8f;

	private FoodMonster monster;

	public Text foodCount;
	public GameObject monsterObject;
	public Camera cam;
	public float rotationDegreesPerSecond = 10f;

	// Use this for initialization
	void Start () {
		monster = FoodMonsterImpl.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		// arrow key rotation control
		float distance = Time.deltaTime * speed;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			float currentAngle = monsterObject.transform.rotation.eulerAngles.z;
			if(Mathf.Abs(90-currentAngle) <= 5){
				monsterObject.transform.rotation = Quaternion.Euler(0, 0, 90);
			} else if(currentAngle > 90 && currentAngle < 270){
				RotateCWise();
			} else {
				RotateCountCWise();
			}
			cam.transform.Translate(new Vector3(-distance, 0, 0));
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			float currentAngle = monsterObject.transform.rotation.eulerAngles.z;
			if(Mathf.Abs(180-currentAngle) <= 5){
				monsterObject.transform.rotation = Quaternion.Euler(0, 0, 180);
			} else if(currentAngle >= 0 && currentAngle < 180){
				RotateCountCWise();
			} else {
				RotateCWise();
			}
			cam.transform.Translate(new Vector3(0,-distance,0));
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			float currentAngle = monsterObject.transform.rotation.eulerAngles.z;
			if(Mathf.Abs(270-currentAngle) <= 5){
				monsterObject.transform.rotation = Quaternion.Euler(0, 0, 270);
			} else if(currentAngle < 270 && currentAngle >= 90){
				RotateCountCWise();
			} else {
				RotateCWise();
			}
			cam.transform.Translate(new Vector3(distance,0,0));
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			float currentAngle = monsterObject.transform.rotation.eulerAngles.z;
			if(Mathf.Abs(0-currentAngle) <= 5){
				monsterObject.transform.rotation = Quaternion.Euler(0, 0, 0);
			} else if(currentAngle > 0 && currentAngle <= 180){
				RotateCWise();
			} else {
				RotateCountCWise();
			}
			cam.transform.Translate(new Vector3(0,distance,0));
		}

		foodCount.text = "Food: " + monster.getCurrentFood();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		monster.eatFood();
		Destroy(collider.gameObject);
	}

	void RotateCountCWise(){
		float currentAngle = monsterObject.transform.rotation.eulerAngles.z;
		float newAngle = currentAngle + rotationDegreesPerSecond;
		monsterObject.transform.rotation = Quaternion.Euler(0, 0, newAngle);
	}

	void RotateCWise(){
		float currentAngle = monsterObject.transform.rotation.eulerAngles.z;
		float newAngle = currentAngle - rotationDegreesPerSecond;
		monsterObject.transform.rotation = Quaternion.Euler(0, 0, newAngle);
	}

}
