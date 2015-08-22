using UnityEngine;
using System.Collections;

public class foodGenerator : MonoBehaviour {
	
	public Transform foodtype;
	public float probability;
	public int maxCookies;
	public int currentCookies;

	// Use this for initialization
	void Start () {
		Vector3 screenPosition;
		
		for (int i=0; i<Random.Range (2, Screen.width/15); i++) {
			screenPosition = Camera.main.ScreenToWorldPoint (
				new Vector3 (Random.Range (0, Screen.width), Random.Range (0, Screen.height), Camera.main.farClipPlane / 2));
			SpawnFood (screenPosition);
			currentCookies++;
		}
	}
	
	// Update is called once per frame
	void Update (){
		if (currentCookies < maxCookies) {
			SpawnFood (RandomOutsideCameraPosition ());
			currentCookies++;
		}
	}
	
	void SpawnFood(Vector3 pos) {
		Instantiate (foodtype, pos, Quaternion.identity);
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
