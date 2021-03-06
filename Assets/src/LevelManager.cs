﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static Level CURRENT;
	
	public FoodMonster monster;

	public Level currentLevel;
	public AudioSource grow;

	// Use this for initialization
	void Start () {
		monster = FoodMonsterImpl.GetInstance();
		Level nextLevel = currentLevel.getNextLevel ();
		CURRENT = currentLevel;

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
		LevelTransition.getInstance ().setManager (this);
		LevelTransition.getInstance ().startTransition ();
		grow.Play();

		this.monster.setCurrentFood(0);
	}

	public void actuallyTransitionToNextLevel() {
		this.currentLevel.Hide ();
		this.currentLevel = currentLevel.getNextLevel();
		CURRENT = this.currentLevel;
		this.currentLevel.Show ();
	}
	
}
