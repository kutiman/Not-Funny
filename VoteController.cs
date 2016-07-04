using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VoteController : MonoBehaviour {

	public Timer timer;
	public int playersCount;

	public Room room;

	// Use this for initialization

	void Awake () {
		timer = new Timer(Time.time, 14, 6);
		timer.cbTimesUp += OnTimeUp;
	}
	
	// Update is called once per frame
	void Update () {
		timer.UpdateTime(Time.time);
	}

	void OnTimeUp () {
		Debug.Log("Moving Scene");
		SceneManager.LoadScene("Results");
	}


}
