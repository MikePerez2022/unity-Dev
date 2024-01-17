using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] TMP_Text scoreText;
	[SerializeField] FloatVariable health;
	[SerializeField] PhysicsCharacterController characterController;
    [Header("Events")]
    [SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;

    private int score = 0;

	public int Score 
	{  
		get { return score; } 
		set 
		{
			score = value;
            scoreText.text = score.ToString();
            scoreEvent.RaisedEvent(score);
        } 
	}

    private void Start()
    {
		health.Value = 5.5f;
    }

    public void AddPoints(int points)
	{
		Score += points;
	}

	private void startGame()
	{
		characterController.enabled = true;
	}
}
