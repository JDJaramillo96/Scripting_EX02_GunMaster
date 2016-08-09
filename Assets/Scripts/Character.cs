using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private int currentWeapon = 0;
	private IWeapon[] weapons = new IWeapon[2];

	void Awake ()
	{
		weapons = GetComponents<IWeapon> ();

		if (weapons == null)
			Debug.LogWarning("null");
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire"))
			weapons[currentWeapon].Shoot ();

		if (Input.GetButtonDown ("ChangeWeapon"))
			ChangeWeapon();
	}

	void OnDrawGizmos()
	{
		//Debug.DrawRay(transform.position, transform.forward, Color.red);
	}

	private void ChangeWeapon()
	{
		int selected = (currentWeapon + 1) % weapons.Length;
		ChangeWeapon (selected);
	}

	private void ChangeWeapon(int selected)
	{
		currentWeapon = selected;
		Debug.Log ("Changed Weapon: " + selected);
	}
}