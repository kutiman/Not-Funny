using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour {

	float waitTime = 0.1f;
	float waitTimeCounter = 0;
	AudioSource sfx;

	public AudioClip tickingClock;

	MemeGenerator memeGenerator;
	VoteController voteController;

	// Use this for initialization
	void Start () {
		sfx = GetComponent<AudioSource>();

		memeGenerator = FindObjectOfType<MemeGenerator>();
		if (memeGenerator != null) {
			memeGenerator.timer.cbTimeIsAlmostUp += PlayTimesUpSound;
			memeGenerator.timer.cbTimesUp += OnTimesUp;
		}

		voteController = FindObjectOfType<VoteController>();
		if (voteController != null) {
			voteController.timer.cbTimeIsAlmostUp += PlayTimesUpSound;
			voteController.timer.cbTimesUp += OnTimesUp;
		}

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