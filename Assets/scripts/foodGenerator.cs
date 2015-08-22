﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodGenerator : MonoBehaviour {
	
	public Transform foodtype;
	public float probability;
	public int maxCookies;
	public int currentCookies;

	public static int cookieID = 0;

	private Level level;

	List<GameObject> foodPool = new List<GameObject>();

	// Use this for initialization
	void Start () {
		Vector3 screenPosition;
		this.level = (Level)this.gameObject.GetComponent (typeof(Level));
		
		for (int i=0; i<5; i++) {
			screenPosition = Camera.main.ScreenToWorldPoint (
				new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), Camera.main.farClipPlane / 2));
			SpawnFood (screenPosition);
			currentCookies++;
		}
	}

	public void notifyEaten(Food food) {
		foodPool.Remove (food.gameObject);
	}
	
	// Update is called once per frame
	void Update (){
		if (foodPool.Count < maxCookies) {
			SpawnFood (RandomOutsideCameraPosition ());
		}
	}
	
	void SpawnFood(Vector3 pos) {
		GameObject gameFood = ((Transform)Instantiate (foodtype, pos, Quaternion.identity)).gameObject;
		gameFood.name = (cookieID++).ToString();
		gameFood.transform.parent = this.gameObject.transform;
		Food food = (Food)gameFood.GetComponent (typeof(Food));
		food.setFoodGenerator (this);
		foodPool.Add(gameFood);
	}
	
	Vector3 RandomOutsideCameraPosition(){
		
		int y=0;
		int x=0;

		int area = Random.Range(0, 4);
		if (area <=0 ) {//bottom
			y = Random.Range(-Screen.height, 0);
			x = Random.Range(0, Screen.width);
		} else if(area <=1){ //top
			y = Random.Range(Screen.height, Screen.height*2);
			x = Random.Range(0, Screen.width);
		} else if(area <=2 ) {//left
			x = Random.Range(-Screen.width, 0);
			y = Random.Range(0, Screen.height);
		} else { //right
			x = Random.Range(Screen.width, Screen.width*2);
			y = Random.Range(0, Screen.height);
		}
		
		Vector3 newPosition = Camera.main.ScreenToWorldPoint( new Vector3(x, y, Camera.main.farClipPlane / 2));
		
		return newPosition;
	}
	
}
