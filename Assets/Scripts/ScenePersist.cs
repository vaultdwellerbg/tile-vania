using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
	private int startingSceneIndex;

	private void Awake()
	{
		int scenePersistsNumber = FindObjectsOfType<ScenePersist>().Length;
		if (scenePersistsNumber > 1)
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
		startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}

	private void Update()
	{
		var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex != startingSceneIndex)
		{
			Destroy(gameObject);
		}
	}

}
