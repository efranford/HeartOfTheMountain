using UnityEngine;
using System.Collections;

public class HeartOfTheMountain : MonoBehaviour {
	
	Zombifier zombifier;
	
	// Use this for initialization
	void Start () {
		zombifier = GameObject.FindGameObjectWithTag("Zombifier").GetComponent<Zombifier>();
	}
	
	void OnTriggerEnter(Collider collider)
	{
		zombifier.Zombify();
		Destroy(gameObject);
	}
}
