using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField] GameObject pickupPrefab = null;
	[SerializeField] AudioClip clip = null;


	private void OnCollisionEnter(Collision collision)
	{
		print(collision.gameObject.name);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Player player))
		{
			AudioSource.PlayClipAtPoint(clip, transform.position);
			player.AddPoints(10);
		}


		Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
