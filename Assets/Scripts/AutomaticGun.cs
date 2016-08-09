using UnityEngine;
using System.Collections;

public class AutomaticGun : Gun{

	[SerializeField]
	private int rounds;

	public override void Shoot ()
	{
		for (int i = 0; i < rounds; i++)
			base.Shoot ();
	}
}