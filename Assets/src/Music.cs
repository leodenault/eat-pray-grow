using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

	private const float LOOP_START = 63.75f;
	private const float UNITY_SUCKS_AT_LIFE_GAP = 0.036f;
	private const float LOOP_END = 108.75f - UNITY_SUCKS_AT_LIFE_GAP;

	private static AudioSource INSTANCE;
	private static AudioSource SWAP;
	private static bool paused = false;
	private static bool isTransitioning = false;

	public AudioSource music;
	public AudioSource swap;

	// Use this for initialization
	void Start () {
		if (INSTANCE == null) {
			INSTANCE = music;
			SWAP = swap;
			DontDestroyOnLoad(INSTANCE);
			DontDestroyOnLoad(SWAP);
			INSTANCE.Play();
		}
	}

	public static void togglePause() {
		paused = !paused;
		if (paused) {
			INSTANCE.Pause();

			if (isTransitioning) {
				SWAP.Pause();
			}
		} else {
			INSTANCE.Play();

			if (isTransitioning) {
				SWAP.Play();
			}
		}
	}

	private void playLooped() {
		INSTANCE.time = LOOP_START;
		INSTANCE.Play();
	}

	void Update() {
		if (!paused) {
			if (INSTANCE.time > LOOP_END && !SWAP.isPlaying) {
				isTransitioning = true;
				SWAP.time = LOOP_START;
				SWAP.Play();
			}

			if (!INSTANCE.isPlaying) {
				isTransitioning = false;
				AudioSource temp = INSTANCE;
				INSTANCE = SWAP;
				SWAP = temp;
			}
		}
	}
}
