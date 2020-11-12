using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float moveSpeed = 1f;
	[SerializeField] float jumpForce = 5f;
	[SerializeField] float climbSpeed = 1f;

	private Rigidbody2D rigidBody;
	private Animator animator;
	private CapsuleCollider2D bodyCollider;
	private BoxCollider2D feetCollider;
	private float initialGravityScale;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		bodyCollider = GetComponent<CapsuleCollider2D>();
		feetCollider = GetComponent<BoxCollider2D>();
		initialGravityScale = rigidBody.gravityScale;
	}

	private void Update()
	{
		Move();
		FlipSprite();
		Jump();
		ClimbLadder();
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
		if (Input.GetButtonDown("Jump") && feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
		{
			Vector2 jumpVelocity = new Vector2(0f, jumpForce);
			rigidBody.velocity = jumpVelocity;
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

	private void ClimbLadder()
	{
		if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
		{
			ConfigureClimbingVelocity();
			rigidBody.gravityScale = 0f;
			animator.SetBool("isClimbing", Mathf.Abs(rigidBody.velocity.y) > Mathf.Epsilon);
		}
		else 
		{
			rigidBody.gravityScale = initialGravityScale;
			animator.SetBool("isClimbing", false);
		}
	}

	private void ConfigureClimbingVelocity()
	{
		float moveInputY = Input.GetAxis("Vertical") * climbSpeed;
		Vector2 climbeVelocity = new Vector2(rigidBody.velocity.x, moveInputY);
		rigidBody.velocity = climbeVelocity;
	}
}
