using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class mainViewModel : MonoBehaviour {

	public void playButtonClicked() {
		SceneManager.LoadScene ("_mainScene");
	}

}
