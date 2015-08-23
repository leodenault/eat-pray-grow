using UnityEngine;
using System.Collections.Generic;

public class BackgroundPosition : MonoBehaviour {

	public Transform monster;

	public List<RectTransform> planes = new List<RectTransform>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i<planes.Count; i++) {
			if(delta (monster.position.x, planes[i].position.x) < -planes[i].rect.width){
				planes[i].Translate(Vector3.right * -2 * planes[i].rect.width);
			}else if(delta (monster.position.x, planes[i].position.x) > planes[i].rect.width){
				planes[i].Translate(Vector3.right * 2 * planes[i].rect.width);
			}

			if(delta (monster.position.y, planes[i].position.y) < -planes[i].rect.height){
				// Translation is made in z because of the rotation of the plane
				planes[i].Translate(Vector3.forward * -2 * planes[i].rect.height);
			}else if(delta (monster.position.y, planes[i].position.y) > planes[i].rect.height){
				// Translation is made in z because of the rotation of the plane
				planes[i].Translate(Vector3.forward * 2 * planes[i].rect.height);
			}
		}
	}

	float delta(float first, float second){
		float sum = first - second;

		return sum;
	}
}
