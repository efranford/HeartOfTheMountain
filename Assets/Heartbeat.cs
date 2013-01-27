using UnityEngine;
using System.Collections;
using System.Timers;

public class Heartbeat : MonoBehaviour {
	
	public AudioClip[] HeartBeats;
	
	private Timer heartBeatL;
	private Timer heartBeatR;
	
	public double HeartRate = 420;
	
	GameObject player;
    Vector3 location;

    bool shouldPlayFirstBeat;
    bool shouldPlaySecondBeat;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Heart");
        /*heartBeatL = new Timer();
        heartBeatL.Elapsed += new ElapsedEventHandler(HeartBeatLElapsed);
        heartBeatL.Interval = HeartRate;
        heartBeatL.Enabled = true;

        heartBeatR = new Timer();
        heartBeatR.Elapsed += new ElapsedEventHandler(HeartBeatRElapsed);
        shouldPlayFirstBeat = true;*/
    }

    void Update()
    {
        /*location = player.transform.position;
        if (shouldPlayFirstBeat && heartBeatL.Enabled)
        {
			audio.PlayOneShot(HeartBeats[0]);
        }
        else if(shouldPlaySecondBeat && heartBeatR.Enabled)
        {
			audio.PlayOneShot(HeartBeats[1]);
        }*/
    }

	private void HeartBeatLElapsed(object sender, ElapsedEventArgs e)
	{
		Debug.Log("LBEAT");
		heartBeatL.Interval = HeartRate;
        shouldPlaySecondBeat = true;
        shouldPlayFirstBeat = false;
		heartBeatL.Enabled = false;
		heartBeatR.Enabled = true;
	}
	private void HeartBeatRElapsed(object sender, ElapsedEventArgs e)
	{
		Debug.Log("RBEAT");
		heartBeatR.Interval = HeartRate;
        shouldPlayFirstBeat = true;
        shouldPlaySecondBeat = false;
		heartBeatR.Enabled = false;
		heartBeatL.Enabled = true;
	}
}
