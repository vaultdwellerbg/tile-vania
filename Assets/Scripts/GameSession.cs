using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
	[SerializeField] int playerLives = 3;
	[SerializeField] int score = 0;
	[SerializeField] Text livesText;
	[SerializeField] Text scoreText;

	private void Awake()
	{
		int gameSessionsNumber = FindObjectsOfType<GameSession>().Length;
		if (gameSessionsNumber > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}

	private void Start()
	{
		livesText.text = playerLives.ToString();
		scoreText.text = score.ToString();
	}

	public void AddToScore(int value)
	{
		score += value;
		scoreText.text = score.ToString();
	}

	public void ProcessPlayerDeath()
	{
		if (playerLives > 1)
		{
			TakePlayerLife();
		}
		else 
		{
			ResetGameSession();
		}
	}

	private void TakePlayerLife()
	{
		playerLives--;
		livesText.text = playerLives.ToString();
		LevelLoader.ReloadCurrentScene();
	}

	private void ResetGameSession()
	{

		Destroy(gameObject);
		LevelLoader.LoadMainMenu();
	}
}
