using UnityEngine;
using System.Collections;



public class AutoDelete : MonoBehaviour {

	private ParticleSystem ps;

	// Use this for initialization
	void Start () {
		this.ps = (ParticleSystem)this.gameObject.GetComponent (typeof(ParticleSystem));
	}
	
	// Update is called once per frame
	void Update () {
	
		if(ps)
		{
			if(!ps.IsAlive())
			{
				Destroy(this.gameObject);
			}
		}

	}
}


