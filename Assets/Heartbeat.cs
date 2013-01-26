using UnityEngine;
using System.Collections;
using System.Timers;

public class Heartbeat : MonoBehaviour {
	
	public AudioClip[] HeartBeats;
	
	private Timer heartBeatL;
	private Timer heartBeatR;
	
	public double HeartRate = .42;
	
	GameObject player;
	
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		heartBeatL = new Timer();
		heartBeatL.Elapsed += new ElapsedEventHandler(HeartBeatLElapsed);
		heartBeatL.Interval = HeartRate;
		heartBeatL.Enabled = true;
		
		heartBeatR = new Timer();
		heartBeatR.Elapsed += new ElapsedEventHandler(HeartBeatRElapsed);
	}
	
	private void HeartBeatLElapsed(object sender, ElapsedEventArgs e)
	{
		Debug.Log("LBEAT");
		AudioSource.PlayClipAtPoint(HeartBeats[0],player.transform.position);
		heartBeatL.Interval = HeartRate;
		heartBeatL.Enabled = false;
		heartBeatR.Enabled = true;
	}
	private void HeartBeatRElapsed(object sender, ElapsedEventArgs e)
	{
		Debug.Log("RBEAT");
		AudioSource.PlayClipAtPoint(HeartBeats[1],player.transform.position);
		heartBeatR.Interval = HeartRate;
		heartBeatR.Enabled = false;
		heartBeatL.Enabled = true;
	}
}
