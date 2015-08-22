using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int requiredTransitionFood;
	public Level nextLevel;
	
	public int getRequiredTransitionFood(){
		return requiredTransitionFood;
	}
	
	public Level getNextLevel(){
		return this.nextLevel;
	}

	public void Hide() {
		gameObject.SetActive (false);
		/*Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in renderers) {
			renderer.enabled = false;
		}*/
	}

	public void Show() {
		gameObject.SetActive (true);
		/*Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in renderers) {
			renderer.enabled = true;
		}*/
	}
}

