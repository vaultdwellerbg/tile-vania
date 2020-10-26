﻿using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float moveSpeed = 1f;

	private Rigidbody2D rigidBody;
	private Animator animator;

	private void Start()
	{
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		Move();
		FlipSprite();
	}

	private void Move()
	{
		float moveInputX = Input.GetAxis("Horizontal") * moveSpeed;
		Vector2 playerVelocity = new Vector2(moveInputX, rigidBody.velocity.y);
		rigidBody.velocity = playerVelocity;

		animator.SetBool("isRunning", moveInputX != 0);
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
