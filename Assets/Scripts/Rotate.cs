using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public int x = 0;
	public int y = 0;
	public int z = 0;

	void OnTriggerEnter(Collider other){
		if(other.name == "WallTrigger"){
			Debug.Log ("1");
			transform.Rotate(x,y,z);
		}
		if(other.name == "Ceiling"){
			Debug.Log ("2");
			transform.Rotate(-x,-y,-z);
		}

	}
}
