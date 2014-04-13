// Make sure that "Play On Awake" is on, and "Loop" is off, for your Audio Source.

using UnityEngine;
using System.Collections;

public class MusicLoop : MonoBehaviour {
	public float loopLength;	// the length of the musical loop in the audio file
	
	IEnumerator LoopCoroutine () {
			yield return new WaitForSeconds (loopLength);
			audio.PlayOneShot(audio.clip);
		
	}
}