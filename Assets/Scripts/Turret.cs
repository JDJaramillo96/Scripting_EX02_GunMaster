using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour, IWeapon {

	[SerializeField]
	private float lifePoints;
	[SerializeField]
	private float damagePerHit;
	[SerializeField]
	private Rigidbody bullet;
	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private float delay = 1f;
	private float countdown;

	void Start()
	{
		countdown = delay;
	}

	void Update ()
	{
		countdown -= Time.deltaTime;

		if (countdown < 0)
		{
			Shoot ();
			countdown = delay;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Bullet")
		{
			Destroy (collision.gameObject);
			lifePoints -= damagePerHit;

			if (lifePoints <= 0)
				Destroy (gameObject);
		}
	}

	public void Shoot()
	{
		SpawnBullet();
	}

	public void SpawnBullet()
	{
		Rigidbody shoot = (Rigidbody)Instantiate (bullet, transform.position + transform.forward * 1f, transform.rotation);
		shoot.velocity = transform.forward * bulletSpeed;
	}
}