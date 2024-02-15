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
	[SerializeField] TMP_Text WeaponUI;
	[SerializeField] Slider healthUI;
	[SerializeField] TMP_Text ScoreUI;

	[SerializeField] FloatVariable health;
	[SerializeField] IntVariable score;
	[SerializeField] PlayerShip player;
	[SerializeField] PathFollower playerPath;

	[Header("Events")]
	[SerializeField] Event gameStartEvent;

	public enum State
	{
		TITLE,
		START_GAME,
		PLAY_GAME,
		WIN,
		GAME_OVER
	}

	private State state = State.TITLE;
	private bool win = false;


	void Update()
	{
		switch (state)
		{
			case State.TITLE:
				titleUI.SetActive(true);
				gameOverUI.SetActive(false);
				WinUI.SetActive(false);
				playerPath.speed = 0;
				break;
			case State.START_GAME:
				titleUI.SetActive(false);
				playerPath.tdistance = 0;
				playerPath.speed = 1;
				player.health.value = 100;
				gameStartEvent.RaiseEvent();
				state = State.PLAY_GAME;
				if (player.health.value <= 0) state = State.GAME_OVER;
				if (win) state = State.WIN;
				break;
			case State.PLAY_GAME:
				if(playerPath.tdistance >= 1) state = State.WIN;
				if (player.health.value <= 0) state = State.GAME_OVER;
				break;
			case State.WIN:
				WinUI.SetActive(true);
				titleUI.SetActive(false);
				gameStartEvent.RaiseEvent();
				playerPath.speed = 0;
				playerPath.tdistance = 1;
				break;
			case State.GAME_OVER:
				gameOverUI.SetActive(true);
				titleUI.SetActive(false);
				gameStartEvent.RaiseEvent();
				playerPath.speed = 0;
				playerPath.tdistance = 0;
				break;
			default:
				break;
		}

		healthUI.value = player.health / 100.0f;
	}

	public void OnStartGame()
	{
		state = State.START_GAME;
	}

	public void OnPlayerDead()
	{
		state = State.TITLE;
	}

	public void OnSwapWeapon()
	{
		if (player.primary) WeaponUI.text = "Lazer";
		else WeaponUI.text = "Rocket";
	}


	public void OnAddPoints(int points)
	{
		ScoreUI.text = player.score.value.ToString();
	}

	public void OnAddHealth(float value)
	{
		if (player.health.value <= 90) player.health.value += value;
		print(value);
	}
}
