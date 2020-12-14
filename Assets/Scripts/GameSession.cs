using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
	[SerializeField] int playerLives = 3;

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
		LevelLoader.ReloadCurrentScene();
	}

	private void ResetGameSession()
	{

		Destroy(gameObject);
		LevelLoader.LoadMainMenu();
	}
}
