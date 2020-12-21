using UnityEngine;

public class CoinPickup : MonoBehaviour
{
	private BoxCollider2D boxCollider;

	private void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (boxCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
		{
			Destroy(gameObject);
		}
	}
}
