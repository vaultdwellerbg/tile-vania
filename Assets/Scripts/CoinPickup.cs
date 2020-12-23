using UnityEngine;

public class CoinPickup : MonoBehaviour
{
	[SerializeField] AudioClip soundClip;
	[SerializeField] int value = 100;

	private BoxCollider2D boxCollider;
	private GameSession gameSession;

	private void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
		gameSession = FindObjectOfType<GameSession>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
		{
			AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position);
			gameSession.AddToScore(value);
			Destroy(gameObject);
		}
	}
}
