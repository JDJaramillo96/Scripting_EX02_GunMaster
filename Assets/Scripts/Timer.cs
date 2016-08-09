using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public float minutes;
	public float seconds;
	private float time;
	private float timeUpdate;
	[SerializeField]
	private Text timeText;

	void Start()
	{
		time = Time.time;
	}

	void Update ()
	{
		timeUpdate = Time.time - time; 
		minutes = (int)(timeUpdate / 60);
		seconds = (int)(timeUpdate % 60);
		timeText.text = "Time: " + minutes.ToString ("00") + ":" + seconds.ToString ("00");
	}
}