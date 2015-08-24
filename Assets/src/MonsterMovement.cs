using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	private const float speed = 9f;
	private Vector3 monsterBaseScale = new Vector3(0.66f, 0.66f, 0.66f);
	private float rotateSpeed = 1f;

	private FoodMonster monster;
	private float playTime;

	public Text foodCount;
	public Text time;
	public GameObject monsterObject;
	public Camera cam;
	public AudioSource nom;

	public Collider2D hitbox;

	private float rotationDegreesPerSecond = 170;

	public GameObject transitionEffect;

	float secondsOfSpinning = 0;

	// Use this for initialization
	void Start () {
		monster = FoodMonsterImpl.GetInstance();
		monster.setHitbox(hitbox);
		monster.setVisible(true);
		monster.reset();
		playTime = 0;
	}

	Vector3 mousePosition;

	// Update is called once per frame
	bool firstTransitionTick = true;
	void Update () {

		if (LevelTransition.getInstance ().getTransitioning ()) {

			this.transform.localScale =  this.transform.localScale * 0.98f;
			if (this.transform.localScale.x < 0.66) {
				this.transform.localScale = monsterBaseScale;
			}
			
			transform.Rotate(Vector3.forward, -1080 * Time.deltaTime);
			secondsOfSpinning += Time.deltaTime;

			if (firstTransitionTick) {
				Instantiate (transitionEffect, this.transform.position, Quaternion.identity);
			}

			firstTransitionTick = false;

			if (secondsOfSpinning > 3) {
				LevelTransition.getInstance().endTransition();
				secondsOfSpinning = 0;
				firstTransitionTick = true;
			}
			return;
		}

		gameObject.SetActive(monster.isVisible());



		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		/*Vector3 dir = (Vector3.right * moveHorizontal * speed * Time.deltaTime) + 
			(Vector3.up * moveVertical * speed * Time.deltaTime); */

		//Vector3 target = dir + this.transform.position;

		Rigidbody2D body = (Rigidbody2D)(this.GetComponent(typeof(Rigidbody2D)));

		if (moveHorizontal > 0) {
			transform.Rotate(Vector3.forward, -rotationDegreesPerSecond * Time.deltaTime * moveHorizontal);
		} else if (moveHorizontal < 0) {
			transform.Rotate(Vector3.forward, rotationDegreesPerSecond * Time.deltaTime * (-moveHorizontal));
		}

		//if (moveVertical > 0) {

			this.transform.Translate(Vector3.up * speed * Time.deltaTime);
			cam.transform.position = new Vector3(this.transform.position.x,
			                                     this.transform.position.y,
			                                     cam.transform.position.z);

		//}

		monster.setPosition(this.transform.position);

		this.transform.localScale = monsterBaseScale * (1 + (0.5f * monster.getCurrentFood() / LevelManager.CURRENT.getRequiredTransitionFood()));
		//Movement
		/*transform.Translate (Vector3.right * moveHorizontal * speed * Time.deltaTime);
		transform.Translate (Vector3.up * moveVertical * speed * Time.deltaTime);*/
		foodCount.text = "Food: " + monster.getTotalFood();
		playTime += Time.deltaTime;
		int minutes = (int)(playTime / 60);
		int seconds = (int)(playTime - (60 * minutes));
		time.text = "Survival time: " + string.Format(
			generateNumberFormat(minutes, 0) + ":" + generateNumberFormat(seconds, 1),
				minutes, seconds);
		
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Food isItFood = collider.gameObject.GetComponent<Food>();
		if (isItFood != null && isItFood.GetType() == typeof(Food)) {
			monster.eatFood((Food)collider.GetComponent(typeof(Food)));
			nom.Play();
			Destroy(collider.gameObject);
		}
	}

	private string generateNumberFormat(int number, int index) {
		return string.Format(number < 10 ? "0{{{0}}}" : "{{{0}}}", index);
	}
}
