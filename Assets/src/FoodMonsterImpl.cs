using UnityEngine;

public class FoodMonsterImpl : FoodMonster {
	private static FoodMonsterImpl INSTANCE;
		
	private int food;
	private Vector2 pos;
	private Collider2D hitbox;
	private bool visible;
		
	private FoodMonsterImpl() {
		food = 0;
		visible = true;
	}

	public static FoodMonster GetInstance() {
		if (INSTANCE == null) {
			INSTANCE = new FoodMonsterImpl();
		}
		return INSTANCE;
	}

	public int getCurrentFood() {
		return food;
	}

	public void setCurrentFood(int quantity) {
		this.food = quantity;
	}

	public void eatFood(Food foodToEat){
		foodToEat.GetEaten ();
		food+= foodToEat.foodValue;
	}

	public Vector3 getPosition() {
		return pos;
	}

	public void setPosition(Vector3 pos) {
		this.pos = pos;
	}

	public Collider2D getHitbox() {
		return hitbox;
	}

	public void setHitbox(Collider2D hitbox) {
		this.hitbox = hitbox;
	}

	public void kill() {
		Application.LoadLevel("title");
	}

	public bool isVisible() {
		return visible;
	}

	public void setVisible(bool visible) {
		this.visible = visible;
	}
}
