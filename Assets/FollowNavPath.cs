using UnityEngine;
using System.Collections;

public class FollowNavPath : MonoBehaviour {
	
	public NavigationPath Path;
	NavMeshAgent agent;
	int currentDestination = 0;
	
	// Use this for initialization
	void Start () {
		//agent = GetComponent<NavMeshAgent>();
		//agent.SetDestination(Path.PointsInPath[currentDestination].position);
			iTween.MoveTo(gameObject, Path.PointsInPath[currentDestination].transform.position, 2);
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(transform.position,Path.PointsInPath[currentDestination].position);
		if(distance < 1)
		{
			if(currentDestination < Path.PointsInPath.Length-1)
			{
				currentDestination++;
			}
			else
			{
				currentDestination = 0;
			}
			
			
			
			iTween.MoveTo(gameObject,Path.PointsInPath[currentDestination].transform.position, distance*10);
			//agent.SetDestination(Path.PointsInPath[currentDestination].position);
		}
		
	}
}
