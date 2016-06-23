using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VoteCanvasController : MonoBehaviour {

	public Text clockObject;
	MemeGenerator memeGenerator;
	Timer timer;

	// Use this for initialization
	void Start () {
		timer = FindObjectOfType<Timer>();

		memeGenerator = FindObjectOfType<MemeGenerator>();
		timer.cbTimeIsAlmostUp += OnTimeIsAlmostUp;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer == null) {
			timer = FindObjectOfType<Timer>();
		}
		int timeLeft = Mathf.CeilToInt( timer.totalTime - timer.timePassed );
		if (timeLeft < 0) {
			timeLeft = 0;
		}
		clockObject.text = timeLeft.ToString();
	}

	void OnTimeIsAlmostUp () {
		clockObject.color = Color.red;
	}
}

