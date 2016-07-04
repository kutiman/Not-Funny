using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoteCanvasController : MonoBehaviour {

	public Text clockObject;
	VoteController voteController;
	Timer timer;

	// Use this for initialization
	void Start () {
		voteController = FindObjectOfType<VoteController>();
		voteController.timer.cbTimeIsAlmostUp += OnTimeIsAlmostUp;
	}
	
	// Update is called once per frame
	void Update () {
		int timeLeft = Mathf.CeilToInt( voteController.timer.totalTime - voteController.timer.timePassed );
		if (timeLeft < 0) {
			timeLeft = 0;
		}
		clockObject.text = timeLeft.ToString();
	}

	void OnTimeIsAlmostUp () {
		clockObject.color = Color.red;
	}
}

