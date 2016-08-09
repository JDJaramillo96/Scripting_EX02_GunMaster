using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public bool turretKill;
	[SerializeField]
	private float damagePerHit;
	[SerializeField]
	private float lifePoints;
	[SerializeField]
	private GameObject gameController;
	[SerializeField]
	private Score score;

	void Awake ()
	{
		score = gameController.GetComponent<Score> ();
	}

	void Start()
	{
		turretKill = false;
	}

	void Update ()
	{
		if (turretKill == true) Time.timeScale = 0f;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Bullet")
		{
			GunDamage ();
			Destroy (collision.gameObject);
		}

		if (collision.transform.tag == "TurretBullet")
		{
			TurretDamage ();
			Destroy (collision.gameObject);
		}
	}

	private void GunDamage()
	{
		lifePoints -= damagePerHit;

		if (lifePoints <= 0)
		{
			Destroy (gameObject);
			score.UpdateScore ();
		}
	}

	private void TurretDamage()
	{
		lifePoints -= damagePerHit;

		if (lifePoints <= 0)
		{
			Destroy (gameObject);
			score.YouLose ();
			turretKill = true;
		}
	}
}