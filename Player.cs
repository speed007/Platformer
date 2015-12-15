using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Rigidbody2D myRigidbody = null; // To cache the rigidboy2D
	private Vector3 vec3Scale; // To cache the vectors of the object
	private float flip = -1; // To turn the player to left from right or to flip upside down
	private float vertical; // To cache the up/down movement  (Jump or Drop)
	[SerializeField]
	private float movementSpeed;
	private bool facingRight;

	
	void Awake () 
	{
		facingRight = true;
		myRigidbody = GetComponent<Rigidbody2D> ();
		vertical = Input.GetAxis("Vertical");
	}

	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis("Horizontal");
		HandleMovement (horizontal);
		Flip (horizontal);
	}

	 private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);
	}

	private void Flip( float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= flip;
			transform.localScale = theScale;
		}
	}
