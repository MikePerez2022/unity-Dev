using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPhysicsEffector : MonoBehaviour
{
	[SerializeField] Transform direction;
	[SerializeField] bool oneTime = true;
	[SerializeField] GameObject player;
	[SerializeField] AudioSource source = null;
	private float timer = 0;

	private void OnTriggerEnter(Collider other)
	{
		if (oneTime && other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
			rb.useGravity = false;
			timer = 4;
			source.Play();
			//rb.AddForce(direction.forward * force, ForceMode.VelocityChange);
		}
	}

	void Update()
	{
		timer = timer - Time.deltaTime;
		if (timer <= 0 && player.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{			
			rb.useGravity = true;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
		{
			//rb.AddForce(direction.forward * force);
		}
	}
}
