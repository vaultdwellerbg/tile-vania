using UnityEngine;

public class Buttons : MonoBehaviour
{
	public void StartGame()
	{
		LevelLoader.LoadNextScene();
	}

	public void MainMenu()
	{
		LevelLoader.LoadMainMenu();
	}
}
