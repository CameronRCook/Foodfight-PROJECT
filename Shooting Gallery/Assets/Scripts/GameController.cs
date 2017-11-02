using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static GameController _instance;

	public float timeLeft = 50;
	public Text timeText;

	private int score;
	public Text ScoreText;
	public Text HighScoreText;

	public static float waitSeconds;
	public static int minTargets = 1;
	public static int maxTargets = 4 ;

	public Texture2D cursorTexture;
	private Vector2 cursorHotspot;

	//[HideInInspector]
	public List<TargetBehavior> targets = new List<TargetBehavior> ();

	void Awake() {
		_instance = this;
		timeText.text = timeLeft.ToString ();
	}

	// Use this for initialization
	void Start () {
		iTween.ValueTo (gameObject, iTween.Hash (
			"from", timeLeft, 
			"to", 0,
			"time", timeLeft,
			"onupdatetarget", gameObject, 
			"onupdate", "tweenUpdate", 
			"oncomplete", "GameComplete"));
		
		StartCoroutine ("SpawnTargets");

		HighScoreText.text = "High Score: " + PlayerPrefs.GetInt ("highScore").ToString ();
		score = 0;

		cursorHotspot = new Vector2 (cursorTexture.width / 2, cursorTexture.height / 2);
		Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
	}

	public void IncreaseScore() {
		score++;
		ScoreText.text = "Score: " + score.ToString ();

		if(score > PlayerPrefs.GetInt("highScore")) {
			PlayerPrefs.SetInt ("highScore", score);
			HighScoreText.text = "High Score: " + score.ToString ();
		}
	}

	void GameComplete () {
		StopCoroutine ("SpawnTargets");
		timeText.color = Color.black;
		timeText.text = "GAME OVER";
	}

	void tweenUpdate (float newValue) {
		timeLeft = newValue;
		if(timeLeft > 10) {
			timeText.text = timeLeft.ToString ("#");

		} else {
			timeText.color = Color.red;
			timeText.text = timeLeft.ToString ("#.0");
		}
	}
		
	void SpawnTarget() {
		int index = Random.Range (0, targets.Count);
		TargetBehavior target = targets [index];
		target.ShowTarget ();
	}

	//runs its self over and over until it is stopped, needs to be started
	IEnumerator SpawnTargets() {
		yield return new WaitForSeconds (waitSeconds);
		while(true) {
			int numOfTargets = Random.Range (minTargets, maxTargets);
			for (int i = 0; i < numOfTargets; i++) {
				SpawnTarget ();
			}

			yield return new WaitForSeconds (Random.Range(0.5f * numOfTargets, 2.5f));
		}
	}

	void Update () {
		Vector3 currentMouse = Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay (currentMouse);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction);
		Debug.DrawLine (ray.origin, hit.point);
	}

	public void IncreaseTime() 
	{
		timeLeft += 5;
	}
}
