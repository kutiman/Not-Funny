using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundController : MonoBehaviour {

	float waitTime = 0.1f;
	float waitTimeCounter = 0;
	AudioSource sfx;

	public AudioClip tickingClock;

	MemeGenerator memeGenerator;
	Timer timer;

	// Use this for initialization
	void Start () {
		sfx = GetComponent<AudioSource>();
		memeGenerator = FindObjectOfType<MemeGenerator>();
		timer = FindObjectOfType<Timer>();

		// registering the sounds to actions
		timer.cbTimeIsAlmostUp += PlayTimesUpSound;
		timer.cbTimesUp += OnTimesUp;
	}
	
	// Update is called once per frame
	void Update () {
		waitTimeCounter -= Time.deltaTime;


	}

	void PlaySound (AudioClip sound) {
		if (waitTimeCounter <= 0 && sound != null) {
			sfx.clip = sound;
			sfx.Play();

			waitTimeCounter = waitTime;
		}
	}

	void PlayTimesUpSound () {
		PlaySound(tickingClock);
	}

	void OnTimesUp () {
		sfx.Stop();
	}
}