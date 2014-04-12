using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour 
{
	public float moveSpeed = 10f;
	
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
	}
}
