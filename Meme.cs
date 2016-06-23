using UnityEngine;
using System.Collections;

public class Meme {

	public string 	 topLine;
	public string bottomLine;
	public Sprite	mySprite;

	public Meme (string topLine, string bottomLine, Sprite mySprite) {
		this.topLine = topLine;
		this.bottomLine = bottomLine;
		this.mySprite = mySprite;
	}
}

