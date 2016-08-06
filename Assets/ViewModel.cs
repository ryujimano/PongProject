using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewModel : MonoBehaviour {


	public static GameObject[] pauseObjects;
	public static GameObject[] playObjects;
	public static GameObject playButton;
	public static GameObject finishedTxt;
	public static GameObject pausedText;

	public scoreUpdate su;

	public static GameObject pauseButton;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("ShowOnPause");
		playObjects = GameObject.FindGameObjectsWithTag ("ShowOnPlay");
		playButton = GameObject.FindGameObjectWithTag ("PlayButton");
		pauseButton = GameObject.FindGameObjectWithTag ("PauseButton");
		finishedTxt = GameObject.FindGameObjectWithTag ("FinishedText");
		pausedText = GameObject.FindGameObjectWithTag ("PausedText");
		hidePaused ();

	}

	public void pauseButtonClicked() {
		Time.timeScale = 0;
		showPaused ();
	}


	public void playButtonClicked() {
		Time.timeScale = 1;
		ball.countDown = 3;
		hidePaused ();
	}

	public void restartButtonClicked() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void mainButtonClicked() {
		SceneManager.LoadScene ("_mainMenuScene");
	}

	public static void showPaused() {
		foreach (GameObject g in pauseObjects) {
			g.SetActive (true);
		}
		foreach (GameObject g in playObjects) {
			g.SetActive (false);
		}
		playButton.SetActive (true);
		pauseButton.SetActive (false);
		pausedText.SetActive (true);
	}

	public static void hidePaused() {
		finishedTxt.SetActive (false);
		foreach (GameObject g in pauseObjects) {
			g.SetActive (false);
		}
		foreach (GameObject g in playObjects) {
			g.SetActive (true);
		}
		playButton.SetActive (false);
		pauseButton.SetActive (true);
		pausedText.SetActive (false);
	}

	public static void showFinished () {
		finishedTxt.SetActive (true);
		foreach (GameObject g in pauseObjects) {
			g.SetActive (true);
		}
		foreach (GameObject g in playObjects) {
			g.SetActive (false);
		}
		playButton.SetActive (false);
		pauseButton.SetActive (false);
		pausedText.SetActive (false);
	}

}
