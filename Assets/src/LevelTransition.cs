using UnityEngine;
using System.Collections;

public class LevelTransition {

	static LevelTransition instance = new LevelTransition ();

	private LevelManager man;

	bool isTransitionning = false;

	public bool getTransitioning() {
		return isTransitionning;
	}

	public void setManager(LevelManager man) {
		this.man = man;
	}

	public static LevelTransition getInstance() {
		return instance;
	}

	public void startTransition() {
		this.isTransitionning = true;

	}

	public void endTransition() {
		this.isTransitionning = false;
		this.man.actuallyTransitionToNextLevel ();
	}
}
