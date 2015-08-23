using UnityEngine;
using System.Collections;

public class LevelTransition {

	static LevelTransition instance = new LevelTransition ();

	bool isTransitionning = false;

	public bool getTransitioning() {
		return isTransitionning;
	}

	public static LevelTransition getInstance() {
		return instance;
	}

	public void startTransition() {
		this.isTransitionning = true;

	}

	public void endTransition() {
		this.isTransitionning = false;
	}
}
