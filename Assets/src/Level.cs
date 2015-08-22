using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public double requiredTransitionFood;
	public Level nextLevel;
	
	public double getRequiredTransitionFood(){
		return requiredTransitionFood;
	}
	
	public Level getNextLevel(){
		return this.nextLevel;
	}

	public void Hide() {
		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in renderers) {
			renderer.enabled = false;
		}
	}

	public void Show() {
		Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in renderers) {
			renderer.enabled = true;
		}
	}
}

