//using UnityEngine;
//using System.Collections;
//using System;
//
//public class Timer : MonoBehaviour {
//
//	MemeGenerator memeGenerator;
//
//	public float totalTime = 20f;
//	public float timePassed = 0;
//	public float endTime = 10f;
//	bool gameIsOn = true;
//
//	public Action cbTimesUp;
//	public Action cbTimeIsAlmostUp;
//
//	float timeAtStart;
//	public bool finalTime = false;
//
//	// Use this for initialization
//	void Start () {
//		memeGenerator = FindObjectOfType<MemeGenerator>();
//		timeAtStart = Time.time;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		timePassed = Time.time - timeAtStart;
//
//		if (gameIsOn) {
//			if (timePassed >= totalTime) {
//				gameIsOn = false;
//				if (cbTimesUp != null) {
//					cbTimesUp ();
//				}
//				Debug.Log("Time Is Up !!!!");
//			}
//
//			if (finalTime == false) {
//				if (totalTime - timePassed <= endTime) {
//					finalTime = true;
//					if (cbTimeIsAlmostUp != null) {
//						cbTimeIsAlmostUp();
//					}
//
//				}
//			}
//		}
//	}
//
//
//}
//

using UnityEngine;
using System.Collections;
using System;

public class Timer {

	public float totalTime = 20f;
	public float timePassed = 0;
	public float endTime = 10f;
	bool gameIsOn = true;
	float timeAtStart;
	public bool finalTime = false;

	public Action cbTimesUp;
	public Action cbTimeIsAlmostUp;

	public Timer (float timeAtStart, float totalTime, float endTime) {
		this.timeAtStart = timeAtStart;
		this.totalTime = totalTime;
		this.endTime = endTime;
	}

	
	// Update is called once per frame
	public void UpdateTime (float currentTime) {
		timePassed = currentTime - timeAtStart;

		if (gameIsOn) {
			if (timePassed >= totalTime) {
				gameIsOn = false;
				if (cbTimesUp != null) {
					cbTimesUp ();
				}
				Debug.Log("Time Is Up !!!!");
			}

			if (finalTime == false) {
				if (totalTime - timePassed <= endTime) {
					finalTime = true;
					if (cbTimeIsAlmostUp != null) {
						cbTimeIsAlmostUp();
					}

				}
			}
		}
	}


}


