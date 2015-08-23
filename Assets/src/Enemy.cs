using UnityEngine;

public class Enemy : MonoBehaviour {

	private const float maxSpeed = 3.0f;

	private FoodMonster monster;
	private Vector3 velocity;

	public GameObject enemy;

	// Use this for initialization
	void Start () {
		monster = FoodMonsterImpl.GetInstance();
		velocity = getDirectionVector();
	}
	
	// Update is called once per frame
	void Update () {
		velocity += getDirectionVector();

		if (velocity.magnitude > maxSpeed) {
			velocity.Normalize();
			velocity *= maxSpeed;
		}

		enemy.transform.Translate(maxSpeed * Time.deltaTime * velocity);
		enemy.transform.rotation = Quaternion.FromToRotation(new Vector3(1, 0, 0), velocity);
		enemy.transform.Rotate(new Vector3(0, 0, -90));
	}

	private Vector3 getDirectionVector() {
		Vector3 monsterPos = monster.getPosition();
		Vector3 distance = monsterPos - enemy.transform.position;
		return distance.normalized;
	}
	
}
