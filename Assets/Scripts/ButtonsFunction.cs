using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonsFunction : MonoBehaviour {

	[SerializeField]
	private GameObject menu;
	private bool pauseActive;

	void Start ()
	{
		pauseActive = true;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.P) || Input.GetKeyDown (KeyCode.Escape))
			pauseActive = !pauseActive;

		if (pauseActive == false)
		{
			menu.SetActive (false);
			Time.timeScale = 1f;
		}

		if (pauseActive == true)
		{
			menu.SetActive (true);
			Time.timeScale = 0f;
		}
	}

	public void Play()
	{
		pauseActive = false;
	}

	public void Restart()
	{
		SceneManager.LoadScene ("Main");
	}

	public void Exit()
	{
		Application.Quit ();
	}
}