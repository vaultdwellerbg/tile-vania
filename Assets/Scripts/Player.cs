using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float moveSpeed = 1f;
	[SerializeField] float jumpForce = 5f;

	private Rigidbody2D rigidBody;
	private Animator animator;
	private CapsuleCollider2D collider;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		collider = GetComponent<CapsuleCollider2D>();
	}

	private void Update()
	{
		Move();
		FlipSprite();
		Jump();
	}

	private void Move()
	{
		float moveInputX = Input.GetAxis("Horizontal") * moveSpeed;
		Vector2 playerVelocity = new Vector2(moveInputX, rigidBody.velocity.y);
		rigidBody.velocity = playerVelocity;

		bool isRunning = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
		animator.SetBool("isRunning", isRunning);
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
		{
			Vector2 jumpVelocity = new Vector2(0f, jumpForce);
			rigidBody.velocity += jumpVelocity;
		}
	}

	private void FlipSprite()
	{
		bool playerHasHorizontalSpeed = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
		if (playerHasHorizontalSpeed) 
		{
			transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
		}
	}
}
