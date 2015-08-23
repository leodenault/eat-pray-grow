using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	private const float LOOP_START = 67.5f;

	private static AudioSource INSTANCE;

	private static bool paused = false;

	public AudioSource music;

	// Use this for initialization
	void Start () {
		if (INSTANCE == null) {
			INSTANCE = music;
			DontDestroyOnLoad(INSTANCE);
			INSTANCE.Play();
		}
	}

	public static void togglePause() {
		paused = !paused;
		if (paused) {
			INSTANCE.Pause();
		} else {
			INSTANCE.Play();
		}
	}

	private void playLooped() {
		INSTANCE.time = LOOP_START;
		INSTANCE.Play();
	}

	void Update() {
		if (!INSTANCE.isPlaying && !paused) {
			playLooped();
		}
	}
}
