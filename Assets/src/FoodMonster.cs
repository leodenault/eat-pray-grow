using UnityEngine;

public interface FoodMonster 
{
	void eatFood(Food food);
	int getCurrentFood();
	void setCurrentFood(int quantity);
	Vector3 getPosition();
	void setPosition(Vector3 pos);
}

