using UnityEngine;
using System.Collections;

public class spawnMove : MonoBehaviour {


	// Use this for initialization
	public float duration = 8.0f;
	public float speed;
	public float vertSpeed;



	//set self destruct timer
	IEnumerator Start () 
	{
		vertSpeed = Random.Range(-10.0f,10.0f);
		yield return StartCoroutine(Countdown(duration));
		Destroy(gameObject);
	}


	// Update is called once per frame
	void Update () 
	{
		//set movement
		transform.position += transform.right*speed*Time.deltaTime;
		transform.position += transform.up*vertSpeed*Time.deltaTime;


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player")
		{
			//	other.GetComponent<PlayerControl>().SetHealth(-1);
			Destroy(gameObject);
		}
	}

	//used to set direction
	public float setSpeed(float newSpeed)
	{
		speed = newSpeed;
		return speed;
	}

	//self destruct delay
	IEnumerator Countdown (float delay)
	{
		yield return new WaitForSeconds(delay);
		
	}
}
