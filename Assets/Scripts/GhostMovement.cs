﻿using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {

	public float speed = 3.0f;
	public float vertSpeed = 1.0f;
	public float verticalCap = 2;
	public Vector2 ghostPos;
	public bool up = true;
	public GameObject player;
	public Vector2 playerPos;
	public GameObject ghostSpawn;
	public float fireRate;
	public float lastGhostLaunched = float.MinValue;
	// Update is called once per frame

	void Start(){

	
	}

	void Update () 
	{

		// move ghost forward
		transform.position += transform.right * speed * Time.deltaTime;
		ghostPos = transform.position;
		
        //upward motion
		if(ghostPos.y < verticalCap && up == true)
		{
			transform.position += transform.up*vertSpeed*Time.deltaTime;
			if (transform.position.y >= verticalCap)
			{

				up = false;
			}
		}

		//downward motion
		if(up == false)
		{
			transform.position += transform.up*-vertSpeed*Time.deltaTime;
			if(ghostPos.y <= -verticalCap){
				up = true;
			}
		}


		//ghost attacks front
		playerPos = player.transform.position;
		Random.seed = (int)(Time.deltaTime * 100);
		fireRate = Random.Range(3.0f,6.0f);
		if (playerPos.x > ghostPos.x && Time.time > lastGhostLaunched + (10.0f/fireRate))
		{
            fireGhost(1);
		}
		//ghost attacks back;

		if (playerPos.x < ghostPos.x&& Time.time > lastGhostLaunched + (10.0f/fireRate))
		{
            fireGhost(-1);
		}

	}

    private void fireGhost(float direction)
    {
        lastGhostLaunched = Time.time;
        GameObject ghost;
        ghost = Instantiate(ghostSpawn, transform.position, transform.rotation) as GameObject;
        ghost.transform.localScale = new Vector2(.25f, .25f);
        ghost.GetComponent<spawnMove>().setSpeed(direction * 14.0f);
    }


}
