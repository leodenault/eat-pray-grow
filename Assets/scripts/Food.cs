

using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	
	public int foodValue;

	private FoodGenerator foodGenerator;

	public void setFoodGenerator(FoodGenerator foodGenerator) {
		this.foodGenerator = foodGenerator;
	}

	public void GetEaten() {
		this.foodGenerator.notifyEaten (this);
	}

	public FoodGenerator getFoodGenerator() {
		return this.foodGenerator;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}