using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	private const float speed = 15f;
	private float rotateSpeed = 1f;

	private FoodMonster monster;

	public Text foodCount;
	public GameObject monsterObject;
	public Camera cam;

	public Collider2D hitbox;

	private float rotationDegreesPerSecond = 120;

	// Use this for initialization
	void Start () {
		monster = FoodMonsterImpl.GetInstance();
		monster.setHitbox(hitbox);
		monster.setVisible(true);
	}

	Vector3 mousePosition;

	// Update is called once per frame
	void Update () {
		// arrow key rotation control
		/*float distance = Time.deltaTime * speed;
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
		} else if(Input.GetKey (KeyCode.RightArrow)) {
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

		Vector3 pos = monsterObject.transform.position;
*/


		gameObject.SetActive(monster.isVisible());



		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		/*Vector3 dir = (Vector3.right * moveHorizontal * speed * Time.deltaTime) + 
			(Vector3.up * moveVertical * speed * Time.deltaTime); */

		//Vector3 target = dir + this.transform.position;

		if (moveHorizontal > 0) {
			transform.Rotate(Vector3.forward, -rotationDegreesPerSecond * Time.deltaTime);
		} else if (moveHorizontal < 0) {
			transform.Rotate(Vector3.forward, rotationDegreesPerSecond * Time.deltaTime);
		}

		//if (moveVertical > 0) {

			this.transform.Translate(Vector3.up * speed * Time.deltaTime);
			cam.transform.position = new Vector3(this.transform.position.x,
			                                     this.transform.position.y,
			                                     cam.transform.position.z);

		//}

		monster.setPosition(this.transform.position);
		//Movement
		/*transform.Translate (Vector3.right * moveHorizontal * speed * Time.deltaTime);
		transform.Translate (Vector3.up * moveVertical * speed * Time.deltaTime);*/


	}

	void OnTriggerEnter2D(Collider2D collider) {
		Food isItFood = collider.gameObject.GetComponent<Food>();
		if (isItFood != null && isItFood.GetType() == typeof(Food)) {
			monster.eatFood((Food)collider.GetComponent(typeof(Food)));
			Destroy(collider.gameObject);
		}
	}


}
