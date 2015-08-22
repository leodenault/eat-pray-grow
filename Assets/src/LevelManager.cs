using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public FoodMonster monster;

	public Level currentLevel;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		double currentFood = monster.getCurrentFood();
		double requiredFood = currentLevel.getRequiredTransitionFood();

		if (currentFood > requiredFood) {
			this.transitionToNextLevel();
		}

	
	}

	void transitionToNextLevel(){


		this.currentLevel.Hide ();
		this.currentLevel = currentLevel.getNextLevel();
		this.currentLevel.Show ();


	}
}
