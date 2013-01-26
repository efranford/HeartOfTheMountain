using UnityEngine;
using System.Collections;

public class MyGameTime : MonoBehaviour {
	
	public Transform[] Suns;
	public float DayCycleInMinutes = 1;
	
	public float CurrentHour { get { return currentHour;}}
	public bool IsDayTime { get { return dayTime; } }
	
	public bool ShowGUI = true;
	
	public UISprite SunMoonCycle;
	
	private const float SECOND = 1;
	private const float MINUTE = 60 * SECOND;
	private const float HOUR = 60 * MINUTE;
	private const float DAY = 24 * HOUR;
	
	private const float DEGREES_PER_SECOND = 360 / DAY;
	
	private float _degreeRotation;
	private float _timeOfDay;
	
	private float _valueOfASecond = 0;
	
	private int Hour = 1;
	private int Minute = 1;
	
	bool dayTime = true;
	bool onlyTwelveHours = true;
	
	private float currentHour;
	
	// Use this for initialization
	void Start () 
	{
		_timeOfDay = 0;
		_degreeRotation = DEGREES_PER_SECOND * DAY / (DayCycleInMinutes * MINUTE);
		float hoursPerMin = 24/DayCycleInMinutes;
		float secondsPerHour = hoursPerMin/60;
		_valueOfASecond = secondsPerHour;
	}
	
	void OnGUI()
	{
		GUILayout.Label(Hour+":"+Minute+((IsDayTime)?" AM":" PM"));
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(Transform sun in Suns)
		{
			sun.Rotate(new Vector3(0,0,_degreeRotation) * Time.deltaTime);
		}
		SunMoonCycle.transform.Rotate(new Vector3(0,0,-_degreeRotation) * Time.deltaTime);
		
		_timeOfDay += Time.deltaTime;// * SecondsModifier;
		
		currentHour = ((_timeOfDay*_valueOfASecond)%24)+1;
		int LastHour = Hour;
		Hour = (int)((_timeOfDay*_valueOfASecond)%12)+1;
		if( Hour == 12 && LastHour == 11)
		{
			dayTime = !dayTime;
			onlyTwelveHours = !onlyTwelveHours;
		}
		Minute = (int)((_timeOfDay*_valueOfASecond*MINUTE)%60);
	}
}
