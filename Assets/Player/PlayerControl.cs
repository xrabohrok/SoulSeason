using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public bool 	 grounded = false;
	public bool   jump = false;
	public float  maxSpeed = 10.8f;
    public float slowerSpeed = 10;
	public float  jumpForce = 700f;
	public float  moveForce = 5f;
	public float 	 groundRadius = 0.2f;
	public float hammerTime;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	
	bool hammering;
	float timeLimit;
	float tempTime;
	float finalTime;
    float currentSpeed;
	
	
	private Animator anim;
	
	void Start()
	{
		anim = GetComponent<Animator>();
        currentSpeed = maxSpeed;
	}
	
	void Update()
	{

		if(hammerTime >= 0)
		{
			//play animation here?
			anim.SetBool("HammerTime", true);
			hammerTime -= Time.deltaTime;
			hammering = true;
		}
		else 
		{
			anim.SetBool("HammerTime", false);
			hammering = false;
		}
	

		transform.Translate(Vector2.right * (currentSpeed/5) * Time.deltaTime);
		
		// If the jump button is pressed and the player is grounded then the player should jump.
		if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && grounded)
			jump = true;
			
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	}
		
	void FixedUpdate()
	{

		if(grounded)
		{
			anim.SetBool("Jump", false);
		}
		else
		{
			anim.SetBool("Jump", true);
		}
		
		if(jump)
		{	
			anim.SetBool("Jump", true);
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}
	}

    public float SetHammer (float buffTimer )
    {
        hammerTime+=buffTimer;
        return hammerTime;
    }
		
	void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log(hammerTime);
		
		if(hammering == true)
		{
			if(coll.gameObject.tag == "Wall")
			{	
				Destroy(coll.gameObject);
			}
		}
	}

    public void SetSlow()
    {
        currentSpeed = slowerSpeed;
    }

	public void SetFast()
    {
        currentSpeed = maxSpeed;
    }
}
