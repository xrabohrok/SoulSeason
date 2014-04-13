using UnityEngine;
using System.Collections;

public class CarrotItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.name == "Player")
		{
			Camera.main.GetComponent<HealthTracker>().SetHealth(1);
			Destroy(gameObject);
		}
	}


}
