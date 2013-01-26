using UnityEngine;
using System.Collections;

public class WorthPoints : MonoBehaviour {
	
	public int PointsWorth = 1;
   void OnCollisionEnter(Collision collision) 
	{
		Debug.Log("Hit "+collision.gameObject.name+" "+PointsWorth);
		
	}
}
