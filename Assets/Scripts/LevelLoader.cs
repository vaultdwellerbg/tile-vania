﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int currentSceneIndex;

	private void Start()
	{
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	public void LoadNextScene()
	{
		SceneManager.LoadScene(currentSceneIndex + 1);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
