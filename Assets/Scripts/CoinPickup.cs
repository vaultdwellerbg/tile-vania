using UnityEngine;

public class CoinPickup : MonoBehaviour
{
	[SerializeField] AudioClip soundClip;

	private BoxCollider2D boxCollider;

	private void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
		{
			AudioSource.PlayClipAtPoint(soundClip, Camera.main.transform.position);
			Destroy(gameObject);
		}
	}
}
