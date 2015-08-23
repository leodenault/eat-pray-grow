using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	
	public int foodValue;

	public GameObject eatenEffect;

	FoodGenerator generator;
	
	public void setFoodGenerator(FoodGenerator generator) {
		this.generator = generator;
	}
	
	public FoodGenerator getLevel() {
		return generator;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void GetEaten() {
		generator.notifyEaten (this);
		Instantiate (eatenEffect, this.transform.position, Quaternion.identity);
	}
}
