using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] AudioSource source;

	private void OnTriggerEnter(Collider other)
	{
		source.Play();
		animator.SetTrigger("Start");
	}


}
