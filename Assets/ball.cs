using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ball : MonoBehaviour {

	public scoreUpdate su;

	public GameObject leftRacket;
	public GameObject rightRacket;

	public static float countDown = 3;
	public float speed = 30;

	public Text countDownTimer;
	public Text finishedText;

	public bool rt = false;
	public bool lt = false;


	float hitPos (Vector2 ballPos, Vector2 racketPos, float racketHeight) {
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void Start () {
		countDown = 3;
		rt = true;
	}

	void Update() {
		if (countDown <= 0) {
			ViewModel.pauseButton.SetActive (false);
		} else {
			ViewModel.pauseButton.SetActive (true);
		}

		if (!(su.gameSetLeft()) && !(su.gameSetRight())) {
			countDown -= Time.deltaTime;
		}

		if (countDown <= 0 && rt && !lt) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
			rt = false;
		} else if (countDown <= 0 && lt && !rt) {
			GetComponent<Rigidbody2D> ().velocity = Vector2.left * speed;
			lt = false;
		}

		if (!(su.gameSetLeft()) && !(su.gameSetRight()) &&countDown <= 0) {
			countDownTimer.text = "";
		} else if (!(su.gameSetLeft()) && !(su.gameSetRight()) && countDown > 0) {	
			countDownTimer.text = ((int)countDown + 1).ToString();
		}

	}

	public void restartRight () {
		transform.position = new Vector3 (-2, 0);
		leftRacket.transform.position = new Vector3 (-20, 0);
		rightRacket.transform.position = new Vector3 (20, 0);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0) * speed;
		countDown = 3;
		rt = true;
		lt = false;
	}

	public void restartLeft () {
		transform.position = new Vector3 (2, 0);
		leftRacket.transform.position = new Vector3 (-20, 0);
		rightRacket.transform.position = new Vector3 (20, 0);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0) * speed;
		countDown = 3;
		rt = false;
		lt = true;
	}

	public void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.name == "RightRacket") {
			float y = hitPos (transform.position, collision.transform.position, collision.collider.bounds.size.y);
			Vector2 dir = new Vector2 (-1, y).normalized;
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}

		if (collision.gameObject.name == "LeftRacket") {
			float y = hitPos (transform.position, collision.transform.position, collision.collider.bounds.size.y);
			Vector2 dir = new Vector2 (1, y).normalized;
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		}

		if (collision.gameObject.name == "LeftWall") {
			su.addScore ("right");
			if (su.gameSetRight()) {
				countDownTimer.text = "Right Wins!";
				gameOver ();
			} else {
				restartLeft ();
			}
		}

		if (collision.gameObject.name == "RightWall") {
			su.addScore ("left");
			if (su.gameSetLeft()) {
				countDownTimer.text = "Left Wins!";
				gameOver ();
			} else {
				restartRight ();
			}
		}
		
	}


	void gameOver () {
		transform.position = new Vector3 (-2, 0);
		leftRacket.transform.position = new Vector3 (-20, 0);
		rightRacket.transform.position = new Vector3 (20, 0);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0) * speed;
		if (su.gameSetLeft ()) {
			ViewModel.showFinished ();
			finishedText.text = "Left Wins!";
		} else {
			ViewModel.showFinished ();
			finishedText.text = "Right Wins!";
		}
	}

}
