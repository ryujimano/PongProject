using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewModel : MonoBehaviour {


	public static GameObject[] pauseObjects;
	public static GameObject[] playObjects;
	public static GameObject playButton;

	public scoreUpdate su;
	public static ball bll;

	public Text pausedText;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag ("ShowOnPause");
		playObjects = GameObject.FindGameObjectsWithTag ("ShowOnPlay");
		playButton = GameObject.FindGameObjectWithTag ("PlayButton");
		hidePaused ();
	}

	public void pauseButtonClicked() {
		showPaused ();
		Time.timeScale = 0;
	}


	public void playButtonClicked() {
		Time.timeScale = 1;
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
	}

	void hidePaused() {
		foreach (GameObject g in pauseObjects) {
			g.SetActive (false);
		}
		foreach (GameObject g in playObjects) {
			g.SetActive (true);
		}
	}
}
