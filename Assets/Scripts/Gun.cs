using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour, IWeapon {

	private int ammo;
	[SerializeField]
	private int capacity;
	[SerializeField]
	private float bulletSpeed;
	[SerializeField]
	private Rigidbody bullet;

	private void Start ()
	{
		Reload();
	}

	private void Update ()
	{
		if (Input.GetButtonDown ("Reload"))
			Reload ();
	}

	public virtual void Shoot()
	{
		if (ammo > 0)
		{
			SpawnBullet();
			ammo--;
		}
	}

	public void Reload()
	{
		ammo = capacity;
	}

	public void SpawnBullet()
	{
		Rigidbody shoot = Instantiate (bullet, transform.position + transform.forward, transform.rotation) as Rigidbody;
		shoot.velocity = transform.forward * bulletSpeed;
	}
}