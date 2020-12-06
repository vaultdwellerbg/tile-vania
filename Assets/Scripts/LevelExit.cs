using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
	[SerializeField] float levelLoadDelay = 2f;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Player player = collision.gameObject.GetComponent<Player>();
		if (player == null) return;

		player.ExitLevel();
		StartCoroutine(LoadNextLevel());
	}

	private IEnumerator LoadNextLevel()
	{
		yield return new WaitForSecondsRealtime(levelLoadDelay);

		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}
}
