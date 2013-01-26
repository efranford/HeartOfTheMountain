using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FootCollider : MonoBehaviour {
	
	public List<AudioClip> Footsteps;
	DateTime lastPlayed;
	bool shouldPlay;
	float lastDuration = 0;
	
	void Start()
	{
		lastPlayed = DateTime.Now;
	}

	void OnTriggerEnter(Collider collider)
	{
		Debug.Log("LD"+lastDuration);
		if(collider.gameObject.name == "Terrain" && ((DateTime.Now - lastPlayed).TotalSeconds > lastDuration))
		{
			Debug.Log("Trigger enter");
			AudioClip clip = Footsteps[UnityEngine.Random.Range(0,Footsteps.Count)];
			lastDuration = clip.length;
			AudioSource.PlayClipAtPoint(clip,gameObject.transform.position);
			lastPlayed = DateTime.Now;
		}
	}
	
	void OnTriggerStay(Collider collider)
	{
		if(collider.gameObject.name == "Terrain")
		{
			Debug.Log("Trigger stay");
			shouldPlay = false;
		}
	}
   
	void OnTriggerExit(Collider other) 
	{		
		if(other.gameObject.name == "Terrain")
		{
			Debug.Log("Trigger exit");
			shouldPlay = false;
		}
    }
}
