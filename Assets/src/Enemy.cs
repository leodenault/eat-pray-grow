using UnityEngine;

public class Enemy : MonoBehaviour {

	private const float MAX_SPEED = 3f;
	private const float ROTATION_FACTOR = 10f;

	private FoodMonster monster;
	private Vector3 velocity;
	private bool killed;
	private float killDelay;

	public GameObject enemy;
	public AudioSource chomp;
	public GameObject eatenEffect;

	// Use this for initialization
	void Start () {
		monster = FoodMonsterImpl.GetInstance();
		velocity = getDirectionVector();
		killed = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = getDirectionVector();
		velocity += (velocity + direction) / ROTATION_FACTOR;

		if (velocity.magnitude > MAX_SPEED) {
			velocity.Normalize();
			velocity *= MAX_SPEED;
		}

		enemy.transform.rotation = Quaternion.FromToRotation(new Vector3(0, 0, 0), velocity);
		enemy.transform.Translate(MAX_SPEED * Time.deltaTime * velocity);
		enemy.transform.rotation = Quaternion.FromToRotation(new Vector3(1, 0, 0), velocity);
		enemy.transform.Rotate(new Vector3(0, 0, -90));

		if (killed) {
			if (killDelay > 0) {
				killDelay -= Time.deltaTime;
			} else {
				monster.kill();
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.Equals(monster.getHitbox())) {
			killDelay = chomp.clip.length * 2;
			killed = true;
			Instantiate(chomp).Play();
			eatenEffect.transform.localScale = new Vector3(3, 3, 1);
			Instantiate(eatenEffect, monster.getPosition(), Quaternion.identity);
			monster.setVisible(false);
		}
	}

	private Vector3 getDirectionVector() {
		Vector3 monsterPos = monster.getPosition();
		Vector3 distance = monsterPos - enemy.transform.position;
		return distance.normalized;
	}
}
