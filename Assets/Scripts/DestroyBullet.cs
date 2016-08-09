using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

	[SerializeField]
	private float time = 1f;
	private float countdown;

	void Start()
	{
		countdown = time;
	}

	void Update ()
	{
		countdown -= Time.deltaTime;

		if (countdown < 0) 
		{
			Destroy (gameObject);
			countdown = time;
		}
	}
}