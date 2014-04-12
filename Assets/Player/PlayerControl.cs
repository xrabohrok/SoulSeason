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
	//public Component 
	/**
	// Update is called once per frame
	void Update() 
	{
		//transform.Translate(Vector2.right * (moveSpeed/5) * Time.deltaTime);
		
		//if((Screen.width/2) >= 
		if(grounded == false)
		{		
			if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
			{
				if(position == 0)
				{
					transform.position = new Vector2(transform.position.x, 0.0001f);
				}
				goUp();
			}
		
			if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
			{
				if(position == 0)
				{
					transform.position = new Vector2(transform.position.x, -0.0001f);
				}
				goDown();
			}
		
		
			if(position == 1 || position == -1)
			{
				rigidbody2D.AddForce(new Vector2(0, (moveSpeed * position)));
			}
		
			if(transform.position.y >= maxHeight)
			{
				//transform.position = new Vector2(transform.position.y, 0f);
				position = 2;
			}
		
			if(transform.position.y <= -maxHeight)
			{
				//transform.position = new Vector2(transform.position.y, 0f);
				position = -2;
			}
		}
		
		if(transform.position.y >= 0 && position == -2)
		{
			position = 0;
			maxHeight = transform.position.y + 2f;
			rigidbody2D.velocity = new Vector2(0, 0);
			rigidbody2D.gravityScale = 0;
			transform.position = new Vector2(transform.position.x, 0f);
		}
		
		if(transform.position.y <= 0 && position == 2)
		{
			position = 0;
			maxHeight = transform.position.y + 2f;
			rigidbody2D.velocity = new Vector2(0, 0);
			rigidbody2D.gravityScale = 0;
			transform.position = new Vector2(transform.position.x, 0f);
		}
		
		if(position == 2 || position == -2)
		{
			rigidbody2D.AddForce(new Vector2(0, (-moveSpeed * (position/2))));
		}
		
		//if(position > 0 && grounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
		//{
			//maxHeight = transform.position.y + 2f;
			//rigidbody2D.AddForce(new Vector2(0, (10*moveSpeed)));		
		//}
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * moveSpeed/5 * Time.deltaTime);
		}
		
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-Vector2.right * moveSpeed/5 * Time.deltaTime);
		}
		
		if (grounded == true && position == 2)
		{
			position = 3;
		}
		
		if (position == 3 && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
		{
			maxHeight = transform.position.y + 2f;
			rigidbody2D.AddForce(new Vector2(0, (10*moveSpeed)));
		}
	}
	
	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	}
	
	void goUp()
	{
		if(position == 0)
		{
			position = 1;
		}
	}
	
	void goDown()
	{
		if(position == 0)
		{
			position = -1;
		}
	}
	*/
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
