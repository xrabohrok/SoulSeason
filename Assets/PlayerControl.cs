using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public float  maxSpeed = 10f;
	public float  jumpForce = 700f;
	public bool   jump = false;
	public float  moveForce = 5f;
	//public int    position = 0;
	//public float  maxHeight;
	
	public bool 	 grounded = false;
	public Transform groundCheck;
	public float 	 groundRadius = 0.2f;
	public LayerMask whatIsGround;	
	void Update()
	{
		transform.Translate(Vector2.right * (maxSpeed/5) * Time.deltaTime);
		// If the jump button is pressed and the player is grounded then the player should jump.
		if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
			jump = true;
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	}
	
	void FixedUpdate()
	{
		
		
		if(!grounded) return;
		
		if(jump)
		{
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}
	
	
}