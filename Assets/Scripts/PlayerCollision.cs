﻿using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	public string collidedTo;

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == collidedTo)
		{
			StartCoroutine("FlyToHeavenWhileFading");
		}
	}
	
	IEnumerator FlyToHeavenWhileFading () {
		Vector3 newPosition = transform.position;
		Color c = renderer.material.color;
		float a, y;

		for (a = 80.0f, y = 5.0f; y < 500.0f; y+=5.0f) {

			c.a = a/100.0f;
			renderer.material.color = c;
			if (a > 0.01f) { a--; } else { a = 0.0f; }

			newPosition.y += y/500.0f;
			transform.position = newPosition;

			yield return new WaitForSeconds(0.016f);
		}
		Destroy (gameObject);
	}
}