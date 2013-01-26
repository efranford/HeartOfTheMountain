using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public UILabel PointLabel;
	HOMPlayer player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<HOMPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		PointLabel.text = player.AcornsCollected.ToString();
	}
}
