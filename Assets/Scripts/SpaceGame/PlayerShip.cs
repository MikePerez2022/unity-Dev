using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour, IDamagable
{
    [SerializeField] private PathFollower path;
    [SerializeField] private Action action;
    //[SerializeField] private GameObject target;
    [SerializeField] private IntEvent scoreEvent;
    [SerializeField] private Inventory inventory;
	[SerializeField] public IntVariable score;
	[SerializeField] public FloatVariable health;

	[SerializeField] private GameObject destroyPrefab;
	[SerializeField] private GameObject hitPrefab;

	[SerializeField] private BoolEvent selected;

	public bool doubleDMG = false;
	public bool primary = true;

	private void Start()
	{
		scoreEvent.Subscribe(AddPoints);
		health.value = 100;
		
	}

	void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            inventory.Use();
        }
		if (Input.GetButtonDown("Fire2"))
		{
			inventory.StopUse();
		}
		path.speed = Input.GetKey(KeyCode.Space) ? 5 : 1;
		if(Input.GetKey(KeyCode.Q) )
		{

			primary = inventory.Swap();
			selected?.RaiseEvent(primary);
		}
	}

	public void AddPoints(int points)
	{
		score.value += points;
		Debug.Log(score.value);
	}

	public void ApplyDamage(float damage)
	{
		health.value -= damage;
		Debug.Log(health.value);
		if (health <= 0)
		{
			if (destroyPrefab != null)
			{
				Instantiate(destroyPrefab, gameObject.transform.position, Quaternion.identity);
			}
			Destroy(gameObject);
		}
		else
		{
			if (hitPrefab != null)
			{
				Instantiate(hitPrefab, gameObject.transform.position, Quaternion.identity);
			}
		}
	}
	public void ApplyHealth(float Health)
	{
		health.value += Health;
		health.value = Mathf.Min(health, 100);
	}
	public void ApplyDMGBoost()
	{
		doubleDMG = true;
	}
}
