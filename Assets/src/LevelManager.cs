using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject[] levels;

	private GameObject currentLevel;

	// Use this for initialization
	void Start () {
		this.currentLevel = levels[0];
	}
	
	// Update is called once per frame
	void Update () {


	
	}
}
