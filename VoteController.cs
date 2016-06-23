using UnityEngine;
using System.Collections;

public class VoteController : MonoBehaviour {

	public Timer timer;

	// Use this for initialization

	void Start () {
		timer = FindObjectOfType<Timer>();
		timer.totalTime = 12f;
		timer.endTime = 6f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
