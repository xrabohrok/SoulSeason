using UnityEngine;
using System.Collections;

public class MoveByForce : MonoBehaviour {
	public float Speed =30.0f;
	public int jump = 20;
	public float gravity = 5;
	public float ray = 1;
	public float jumpHeight =4.0f;
	public float currentSpeed = 30.0f;
	Vector3 LVelocity;
	public float counterSpeed=  -30.0f;
	public float speedLimit = 8.0f;
	public int screenAlign = 1;
	Vector3 JumpPos;
	//movement goals:
	//emulate standard sidescroller movement
	//current status:
	//back and forth movement enabled, jumping enabled, movement speed reduced in air. Movement force, jumpforce and gravity shifts adjustable.
	//current issues:
	//character slides when movement is released, constant acceleration, reduced movement in air uses raycast that isn't always accurate,
	//character will attempt to "climb" or stick to walls if movement key is held down while against barrier. 
	//possible solutions:
	//to counter character slide, drag can be temporarly increased, or an opposing force may be applied. To counter constant acceleration, will
	//attempt to apply a consistant counter force when a max speed is reached. To fix the raycast issue will test a spherecast. If spherecasting is successful
	//for correcting raycast issues, will consider it's use for detecting wall bumps. This would allow me to implement wall climb fixes.
	//corrections implemented
	//added counterforce after speedlimit.
	//results:
	//counterforce effectively limits speed at a variety of Drag settings, minor numeric velocity shifts do not appear noticable.


	// Use this for initialization
	void FixedUpdate() {
		//rotation input
		if(Input.GetKeyDown("h"))
		   RotateOne();
		if(Input.GetKeyDown("j"))
			RotateTwo();
		if(Input.GetKeyDown("k"))
			RotateThree();
		if(Input.GetKeyDown("l"))
			RotateFour();

		//set the speedlimit force
		counterSpeed = currentSpeed*-1;
		//speed check
		LVelocity = transform.InverseTransformDirection(rigidbody.velocity);
		//Debug.Log(LVelocity);
		//Debug.Log(LVelocity[0]);
		//movement
		float h = Input.GetAxis("Horizontal");
		rigidbody.AddForce(transform.right*(currentSpeed*h), ForceMode.Acceleration);
			if(LVelocity[0] > speedLimit || LVelocity[0] < -speedLimit){
			rigidbody.AddForce(transform.right*(counterSpeed*h), ForceMode.Acceleration);
		}
		// Mananaging jumps, checks if on top of something,increases gravity at a height, and kills speed
		RaycastHit GravChange;
		Ray JumpRay = new Ray(transform.position, Vector3.down);
		//test ray 
		Debug.DrawRay(transform.position, Vector3.down*ray);
		rigidbody.AddForce(transform.up*-gravity);

		if(Physics.Raycast(JumpRay, out GravChange)){
			float height = GravChange.distance;
			if (height >= 1.2)
				currentSpeed = (Speed/2);
			if (height > jumpHeight + JumpPos[1] ){
				rigidbody.AddForce(transform.up*(-gravity*4));
			}
		//	if(Physics.Raycast(JumpRay, ray)){
			if (screenAlign == 1){
				if(Physics.SphereCast(transform.position,.5f, Vector3.down,out GravChange,1.0f)){
				currentSpeed = Speed;
				if(Input.GetButtonDown("Jump")){
					Debug.Log (JumpPos);
					rigidbody.AddForce(transform.up*jump, ForceMode.Force);
							}
				}
	}
			if (screenAlign == 2){
				if(Physics.SphereCast(transform.position,.5f, Vector3.right,out GravChange,1.0f)){
					currentSpeed = Speed;
					if(Input.GetButtonDown("Jump")){
						JumpPos = transform.position;
						Debug.Log (JumpPos);
						rigidbody.AddForce(transform.up*jump, ForceMode.Force);
							}
				}
	}
			if (screenAlign == 3){
					if(Physics.SphereCast(transform.position,.5f, Vector3.up,out GravChange,1.0f)){
						currentSpeed = Speed;
						if(Input.GetButtonDown("Jump")){
						JumpPos = transform.position;

							Debug.Log (JumpPos);
							rigidbody.AddForce(transform.up*jump, ForceMode.Force);
							}
					}
	}
			if (screenAlign == 4){
			if(Physics.SphereCast(transform.position,.5f, Vector3.left,out GravChange,1.0f)){
						currentSpeed = Speed;
						if(Input.GetButtonDown("Jump")){
						JumpPos = transform.position;
							Debug.Log (JumpPos);
							rigidbody.AddForce(transform.up*jump, ForceMode.Force);
							}
					}
		
		
		


		}
		}
	
		

	}
	
	int RotateOne(){
		if (screenAlign == 1){
		transform.Rotate(0,0,90);
		}
		if (screenAlign == 3){
		transform.Rotate(0,0,-90);
		}
		if (screenAlign == 4){
		transform.Rotate(0,0,180);
		}
		screenAlign = 2;
		return screenAlign;
		
	}

	int RotateTwo(){
		if (screenAlign == 2){
			transform.Rotate(0,0,90);
		}
		if (screenAlign == 4){
			transform.Rotate(0,0,-90);
		}
		if (screenAlign == 1){
			transform.Rotate(0,0,180);
		}
		screenAlign = 3;
		return screenAlign;
		
	}
	int RotateThree(){
		if (screenAlign == 3){
			transform.Rotate(0,0,90);
		}
		if (screenAlign == 1){
			transform.Rotate(0,0,-90);
		}
		if (screenAlign == 2){
			transform.Rotate(0,0,180);
		}
		screenAlign = 4;
		return screenAlign;
		
	}
	int RotateFour(){
		if (screenAlign == 4){
			transform.Rotate(0,0,90);
		}
		if (screenAlign == 2){
			transform.Rotate(0,0,-90);
		}
		if (screenAlign == 3){
			transform.Rotate(0,0,180);
		}
		screenAlign = 1;
		return screenAlign;
		
	}


		
}
