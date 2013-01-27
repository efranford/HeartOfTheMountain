using UnityEngine;
using System.Collections;

public class HOMButton : MonoBehaviour {
	
	public string LevelToLoad;

	void OnClick()
	{
		Application.LoadLevel(LevelToLoad);
	}
}
