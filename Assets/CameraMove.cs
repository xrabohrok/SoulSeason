using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float speed = 3.0f;
	// Use this for initialization
	void Update () 
	{
		//set movement
		transform.position += transform.right*speed*Time.deltaTime;
		
	}

}
