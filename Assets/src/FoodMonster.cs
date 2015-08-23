using UnityEngine;

public interface FoodMonster 
{
	void eatFood(Food food);
	int getCurrentFood();
	void setCurrentFood(int quantity);
	Vector3 getPosition();
	void setPosition(Vector3 pos);
	Collider2D getHitbox();
	void setHitbox(Collider2D hitbox);
	void kill();
	bool isVisible();
	void setVisible(bool visible);
	void reset();
	int getTotalFood();
}

