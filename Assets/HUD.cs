using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public UILabel PointLabel;
	HOMPlayer player;

    public GameObject LoseScreen;
    public GameObject WinScreen;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<HOMPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (player.State == PlayerState.Dead)
        {
            LoseScreen.SetActive(true);
        }
        else if(player.State == PlayerState.Won)
        {
            WinScreen.SetActive(true);
        }
		PointLabel.text = player.AcornsCollected.ToString();

	}
}
