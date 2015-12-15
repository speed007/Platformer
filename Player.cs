using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Rigidbody2D myRigidbody = null; // To cache the rigidboy2D
	private float moveLeft = -1f; // To move the player left
	private Transform myTransform = null; // To cache the transform of the object
	private Vector3 vec3Scale; // To cache the vectors of the object
	[SerializeField]
	private float vec3ScaleX = 1; // To cache Vec3X value
	[SerializeField]
	private float vec3ScaleY = 1; // To cache Vec3Y value
	[SerializeField]
	private float vec3ScaleZ = 1; // To cache Vec3Z value
	private float flip = -1; // To turn the player to left from right or to flip upside down
	private float horizontal; // To cache the left/right movement
	private float vertical; // To cache the up/down movement  (Jump or Drop)
	[SerializeField]
	private float movementSpeed;

	
	void Awake () 
	{
		myRigidbody = GetComponent<Rigidbody2D> ();
		myTransform = GetComponent<Transform> ();
		vec3Scale = new Vector3 (vec3ScaleX, vec3ScaleY, vec3ScaleZ);
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
	}

	void Update () 
	{
		horizontal = Input.GetAxis("Horizontal");
		HandleMovement ();
	}
	 private void HandleMovement()
	{

		//myTransform.localScale = new Vector3 (vec3Scale.x * flip, vec3Scale.y, vec3Scale.z);
		myRigidbody.velocity = new Vector2 (horizontal, vertical) * movementSpeed;
