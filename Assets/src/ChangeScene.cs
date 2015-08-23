using UnityEngine;

public class ChangeScene : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.Return) ||
			Input.GetKeyDown(KeyCode.KeypadEnter)) {
			Application.LoadLevel("world");
		}
	}
}
