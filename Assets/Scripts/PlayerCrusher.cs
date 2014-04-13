using UnityEngine;
using System.Collections;

public class PlayerCrusher : MonoBehaviour {

    public Transform respawnPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = respawnPoint.transform.position;
            other.GetComponent<PlayerControl>().SetFast();
        }
    }
}
