using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] GameObject titleUI;
	[SerializeField] GameObject gameOverUI;
	[SerializeField] GameObject WinUI;
	[SerializeField] TMP_Text livesUI;
	[SerializeField] TMP_Text timerUI;
	[SerializeField] Slider healthUI;

	[SerializeField] FloatVariable health;
	[SerializeField] GameObject respawn;
	[SerializeField] Player player;

	[Header("Events")]
	[SerializeField] Event gameStartEvent;
	[SerializeField] GameObjectEvent respawnEvent;
	[SerializeField] FloatEvent gravEvent;

	public enum State
	{
		TITLE,
		START_GAME,
		PLAY_GAME,
		WIN,
		GAME_OVER
	}

	private State state = State.TITLE;
	private float timer = 0;
	private int lives = 0;
	private int Deaths = 0;
	private bool win = false;

	public int Lives { 
		get { return lives; } 
		set { 
			lives = value; 
			livesUI.text = "LIVES: " + lives.ToString(); 
			} 
	}

	public float Timer
	{
		get { return timer; }
		set
		{
			timer = value;
			timerUI.text = string.Format("{0:F1}", timer);
		}
	}

	void Update()
	{
		switch (state)
		{
			case State.TITLE:
				titleUI.SetActive(true);
				gameOverUI.SetActive(false);
				WinUI.SetActive(false);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
			case State.START_GAME:
				titleUI.SetActive(false);
				Timer = 60;
				Lives = 3 - Deaths;
				health.value = 100;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				gameStartEvent.RaiseEvent();
				respawnEvent.RaiseEvent(respawn);
				state = State.PLAY_GAME;
				if (Deaths >= 4) state = State.GAME_OVER;
				if (win) state = State.WIN;
				break;
			case State.PLAY_GAME:
				Timer = Timer - Time.deltaTime;
				if (Timer <= 0)
				{
					state = State.GAME_OVER;
				};
				if(player.Score == 150) state = State.WIN;
				break;
			case State.WIN:
				WinUI.SetActive(true);
				titleUI.SetActive(false);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				gameStartEvent.RaiseEvent();
				break;
			case State.GAME_OVER:
				gameOverUI.SetActive(true);
				titleUI.SetActive(false);
				Deaths = 4;
				gameStartEvent.RaiseEvent();
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
			default:
				break;
		}

		healthUI.value = health / 100.0f;
	}

	public void OnStartGame()
	{
		state = State.START_GAME;
	}

	public void OnPlayerDead()
	{
		state = State.TITLE;
	}

	public void OnLifeLost()
	{
		Deaths++;
	}

	public void OnAddPoints(int points)
	{
		print(points);
	}
	public void OnAddTime(float value)
	{
		Timer += value;
		print(value);
	}

	public void OnAddHealth(float value)
	{
		if (health.value <= 90) health.value += value;
		print(value);
	}
}
