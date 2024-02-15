using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] GameObject pickupPrefab;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent(out PlayerShip player))
		{
			player.ApplyHealth(health);
			Debug.Log(health + "Healed");
			if (pickupPrefab != null) Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
