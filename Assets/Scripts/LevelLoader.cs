using UnityEngine.SceneManagement;

public class LevelLoader
{
	public static void LoadNextScene()
	{
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}

	public static void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public static void ReloadCurrentScene()
	{
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}
}
