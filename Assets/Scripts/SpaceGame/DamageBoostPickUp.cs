using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostPickUp : MonoBehaviour
{
	[SerializeField] private AmmoData primary;
	[SerializeField] GameObject pickupPrefab;

	Coroutine timerCoroutine;

	private void Start()
	{
		primary.damage = 10;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.TryGetComponent(out PlayerShip player))
		{
			player.ApplyDMGBoost();
			primary.damage *= 2;
			Debug.Log(primary.damage);
			if (pickupPrefab != null) Instantiate(pickupPrefab, transform.position, Quaternion.identity);
			timerCoroutine = StartCoroutine(BoostTimerCR(player));
		}
	}
	IEnumerator BoostTimerCR(PlayerShip player)
	{
		while (player.doubleDMG)
		{
			float time = 5;
			yield return new WaitForSeconds(time);
			primary.damage /= 2;
			Debug.Log(primary.damage);
			Destroy(gameObject);
			player.doubleDMG = false;
		}
	}

}
