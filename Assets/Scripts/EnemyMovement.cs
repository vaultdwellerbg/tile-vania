using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] float moveSpeed = 1f;

	Rigidbody2D rigidBody;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		float direction = IsFacingRight() ? 1f : -1f;
		rigidBody.velocity = new Vector2(moveSpeed * direction, rigidBody.velocity.y);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Foreground")
		{
			FlipSprite();
		}
	}

	private bool IsFacingRight()
	{
		return transform.localScale.x > 0f;
	}

	private void FlipSprite()
	{
		float newDirection = -Mathf.Sign(rigidBody.velocity.x);
		transform.localScale = new Vector2(newDirection, 1f);
	}
}
