using UnityEngine;

public class FoodMonsterImpl : FoodMonster {
	private static FoodMonsterImpl INSTANCE;
		
	private int food;
	private Vector2 pos;
		
	private FoodMonsterImpl() {
		food = 0;
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

	public void eatFood(){
		food++;
	}

	public Vector3 getPosition() {
		return pos;
	}

	public void setPosition(Vector3 pos) {
		this.pos = pos;
	}
}
