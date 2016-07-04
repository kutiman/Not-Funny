using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;

public class MemeGenerator : MonoBehaviour {

	Meme levelMeme;
	CanvasController canvasController;

	public Timer timer;
	bool gameIsOn = true;

	public bool memePosted = false;

	Sprite levelPicture;
	string topLine;
	string bottomLine;

	public Action<Meme> cbMemeCreated;
	public Action<String> cbTopLineChanged;
	public Action<String> cbBottomLineChanged;

	void Awake () {
		timer = new Timer(Time.time, 9, 6);
	}
	// Use this for initialization
	void Start () {
		cbMemeCreated += ShowDebug;

		timer.cbTimesUp += OnTimeUp;
		canvasController = FindObjectOfType<CanvasController>();
	}
	
	// Update is called once per frame
	void Update () {
		timer.UpdateTime(Time.time);
	}

	public void CreateMeme (Button button) {
		Meme meme = new Meme (topLine, bottomLine, levelPicture);
		if (cbMemeCreated != null) {
			cbMemeCreated(meme);
		}

		memePosted = !memePosted;
		ChangeButtonColor(button);
	}

	void ShowDebug (Meme meme) {
		Debug.Log(meme.topLine + "\n" + bottomLine);
	}

	public void ChangeTopLine (string txt) {
		Debug.Log("ChangeTopLine ---- " + txt);
		if (txt == null) {
			return;
		}
		topLine = txt;
		if (cbTopLineChanged != null) {
			cbTopLineChanged(txt);
		}
	}

	public void ChangeBottomLine (string txt) {
		Debug.Log("ChangeBottomLine ---- " + txt);
		if (txt == null) {
			return;
		}
		bottomLine = txt;
		if (cbBottomLineChanged != null) {
			cbBottomLineChanged(txt);
		}
	}

	void OnTimeUp () {
		Debug.Log("Moving Scene");
		SceneManager.LoadScene("Voting");
	}

	public void ChangeButtonColor (Button button) {
		Debug.Log("Changing the button color!");
		Color newColor;
		String buttonText;


		if (memePosted) {
			newColor = Color.red;
			buttonText = "Undo";

			canvasController.ift.SetActive(false);
			canvasController.ifb.SetActive(false);
		}
		else {
			newColor = Color.blue;
			buttonText = "Post";
			canvasController.ift.SetActive(true);
			canvasController.ifb.SetActive(true);
		}
		button.image.color = newColor;
		button.GetComponentInChildren<Text>().text = buttonText;
	}
}

