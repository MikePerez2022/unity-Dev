using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTime : MonoBehaviour
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
			player.AddTime(15.0f);
		}


		Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
