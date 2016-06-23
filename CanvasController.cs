using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	public Text topLineObject;
	public Text bottomLineObject;
	public Text clockObject;
	MemeGenerator memeGenerator;
	Timer timer;

	// Use this for initialization
	void Start () {
		timer = FindObjectOfType<Timer>();

		memeGenerator = FindObjectOfType<MemeGenerator>();
		memeGenerator.cbTopLineChanged += ChangeUITextTop;
		memeGenerator.cbBottomLineChanged += ChangeUITextBottom;
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

	public void ChangeUITextTop (string txt) {
		topLineObject.text = txt;
		Debug.Log ("ChangeUITextTop -- " + txt);
	}

	public void ChangeUITextBottom (string txt) {
		bottomLineObject.text = txt;
		Debug.Log ("ChangeUITextBottom -- " + txt);
	}

	void OnTimeIsAlmostUp () {
		clockObject.color = Color.red;
	}
}
