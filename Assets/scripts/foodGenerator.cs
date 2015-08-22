using UnityEngine;
using System.Collections;

public class foodGenerator : MonoBehaviour {

	public Transform foodtype;
	public float probability;

	// Use this for initialization
	void Start () {
		Vector3 screenPosition;

		for (int i=0; i<Random.Range (2, Screen.width/15); i++) {
			screenPosition = Camera.main.ScreenToWorldPoint (
			new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), Camera.main.farClipPlane / 2));
			SpawnFood (screenPosition);
		}
	}
	
	// Update is called once per frame
	void Update () {
		/*if(foodtype.childCount < 40){
			Vector3 screenPosition = Camera.main.ScreenToWorldPoint(
				new Vector3(Random.Range(Screen.width,Screen.width*2), Random.Range(Screen.height, Screen.height*2), Camera.main.farClipPlane/2));
			SpawnFood (screenPosition);
		}*/
	}

	void SpawnFood(Vector3 pos) {
		Instantiate (foodtype, pos, Quaternion.identity);
	}
}
