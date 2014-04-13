using UnityEngine;
using System.Collections;

public class SlowZone : MonoBehaviour {

    PlayerControl playerMotor;

	// Use this for initialization
	void Start () {
        playerMotor = GameObject.FindObjectOfType<PlayerControl>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMotor.SetSlow();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerMotor.SetFast();
        }
    }
}
