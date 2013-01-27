using UnityEngine;
using System.Collections;

public class PlayAnimationWhenPlayerIsInRange : MonoBehaviour {
	public float DistanceToActivateAnimation = 1.0f;
	public string AnimationToPlay;
	bool played = false;
	void OnTriggerEnter(Collider collider)
	{
		if(!played)
		{
			animation.Play(AnimationToPlay);
			played = true;
		}
	}
}
