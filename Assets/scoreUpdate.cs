using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreUpdate : MonoBehaviour {

	public Text scoreText;
	public int leftScore = 0;
	public int rightScore = 0;
	public string score = "0 - 0";

	public void addScore(string wall) {
		if (wall == "left") {
			leftScore += 1;
			score = leftScore + " - " + rightScore;
			scoreText.text = score;
		} else if (wall == "right") {
			rightScore += 1;
			score = leftScore + " - " + rightScore;
			scoreText.text = score;
		}
	}

	public bool gameSetLeft() {
		if (leftScore >= 7) {
			return true;
		} else {
			return false;
		}
	}

	public bool gameSetRight() {
		if (rightScore >= 7) {
			return true;
		} else {
			return false;
		}
	}
}
