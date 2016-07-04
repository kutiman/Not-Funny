using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

	public Text topLineObject;
	public Text bottomLineObject;
	public Text clockObject;

	public GameObject ift;
	public GameObject ifb;

	MemeGenerator memeGenerator;

	// Use this for initialization
	void Start () {

		memeGenerator = FindObjectOfType<MemeGenerator>();
		memeGenerator.cbTopLineChanged += ChangeUITextTop;
		memeGenerator.cbBottomLineChanged += ChangeUITextBottom;
		memeGenerator.timer.cbTimeIsAlmostUp += OnTimeIsAlmostUp;

		ift = GameObject.Find("InputFieldTop");
		ifb = GameObject.Find("InputFieldBottom");
	}
	
	// Update is called once per frame
	void Update () {
		int timeLeft = Mathf.CeilToInt( memeGenerator.timer.totalTime - memeGenerator.timer.timePassed );
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
