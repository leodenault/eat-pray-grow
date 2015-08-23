using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public FoodMonster monster;

	public Level currentLevel;

	// Use this for initialization
	void Start () {
		monster = FoodMonsterImpl.GetInstance();
		Level nextLevel = currentLevel.getNextLevel ();

		while (nextLevel != currentLevel) {
			nextLevel.Hide();
			nextLevel = nextLevel.getNextLevel();
		}

		currentLevel.Show ();
	}
	
	// Update is called once per frame
	void Update () {

		int currentFood = monster.getCurrentFood();
		int requiredFood = currentLevel.getRequiredTransitionFood();

		if (currentFood > requiredFood) {
			this.transitionToNextLevel();
		}

	
	}

	void transitionToNextLevel(){

		LevelTransition.getInstance ().startTransition ();

		this.monster.setCurrentFood(0);
		this.currentLevel.Hide ();
		this.currentLevel = currentLevel.getNextLevel();
		this.currentLevel.Show ();


	}
}
