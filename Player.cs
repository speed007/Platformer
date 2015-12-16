using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Rigidbody2D myRigidbody = null; // To cache the rigidboy2D
	private Vector3 vec3Scale; // To cache the vectors of the object
	private float flip = -1; // To turn the player to left from right or to flip upside down
	[SerializeField]
	private float movementSpeed;
	private bool facingRight;
	private float horizontal;
	private Animator myAnimator;
	private bool attacked;
//	private float vertical; // To cache the up/down movement  (Jump or Drop)
	
	void Awake () 
	{
		facingRight = true;
		myRigidbody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
		//
	}

	void FixedUpdate () 
	{
		Axis ();
		HandleMovement ();
		Flip ();
		Animate ();
		Attack ();
	}

	// Get the controls
	private void Axis()
	{
		horizontal = Input.GetAxis("Horizontal");
//		vertical = Input.GetAxis("Vertical");
	}

	// Move the character
	 private void HandleMovement()
	{
		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);
			
	}

	// Face the character left or right
	private void Flip()
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) 
		{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= flip;
			transform.localScale = theScale;
		}
	}

	//Animate the charactor
	private void Animate()
	{
		if (horizontal > 0 || horizontal < 0 && !attacked) 
		{
			myAnimator.SetBool ("IsRunnig", true);
		} 
		else 
		{
			myAnimator.SetBool ("IsRunnig", false);
		}

	}

	//Attack Animation
	private void Attack()
	{
		if (attacked)
		{
			myAnimator.SetTrigger("attack");
		}
	}

	private void HandleInput()
	{
	
		if (Input.GetKeyDown (KeyCode.RightShift))
		{
			attacked = true;
		}
	}



}
