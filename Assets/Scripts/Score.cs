using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public float score;
	private bool scoreActive;
	[SerializeField]
	public float scoreLimit;
	[SerializeField]
	public Text scoreText;
	[SerializeField]
	private GameObject winText;
	[SerializeField]
	private GameObject loseText;
	[SerializeField]
	private GameObject pressEscape;

	private Timer timer;

	void Awake()
	{
		timer = GetComponent<Timer> ();
	}

	void Start ()
	{
		score = 0;
		scoreActive = true;
		winText.SetActive (false);
		loseText.SetActive (false);
		pressEscape.SetActive (false);
	}

	void Update ()
	{
		scoreText.text = (scoreActive == true) ? "Score: " + score : "";

		if (timer.seconds < 12 && score == scoreLimit)
		{
			YouWin ();
			Time.timeScale = 0f;
		}

		if (timer.seconds >= 12)
		{
			YouLose ();
			Time.timeScale = 0f;
		}
	}

	public void YouLose()
	{
		loseText.SetActive (true);
		pressEscape.SetActive (true);
		scoreActive = false;
	}

	public void YouWin()
	{
		winText.SetActive (true);
		pressEscape.SetActive (true);
		scoreActive = false;
	}

	public void UpdateScore()
	{
		score = score + 10;
	}
}