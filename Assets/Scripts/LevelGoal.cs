using UnityEngine;
using System.Collections;

public class LevelGoal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other){
		if (other.name =="Player")
		{
            Debug.Log("Win");
			Application.LoadLevel(3);

		}
		if (other.name =="ghost")
		{
			Application.LoadLevel(2);
		}


	}
}
