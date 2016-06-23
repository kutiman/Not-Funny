using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class MemeGenerator : MonoBehaviour {

	Meme levelMeme;

	public Timer timer;
	bool gameIsOn = true;

	Sprite levelPicture;
	string topLine;
	string bottomLine;

	public Action<Meme> cbMemeCreated;
	public Action<String> cbTopLineChanged;
	public Action<String> cbBottomLineChanged;

	void Awake () {
		timer = FindObjectOfType<Timer>();
		timer.totalTime = 9f;
		timer.endTime = 11f;
	}
	// Use this for initialization
	void Start () {
		cbMemeCreated += ShowDebug;
		timer.cbTimesUp += OnTimeUp;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateMeme () {
		Meme meme = new Meme (topLine, bottomLine, levelPicture);
		if (cbMemeCreated != null) {
			cbMemeCreated(meme);
		}
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
		SceneManager.LoadScene(1);
	}
}

