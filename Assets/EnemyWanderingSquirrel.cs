using UnityEngine;
using System.Collections;

public class EnemyWanderingSquirrel : MonoBehaviour {
	
	NavMeshAgent agent;
	public Transform Target;
	
	public GameObject EyeLidL;
	public GameObject EyeLidR;
	public GameObject Body;
	
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(Target.position);
	}
	
	void Update()
	{
		agent.SetDestination(Target.position);
		
		if(agent.isPathStale || Vector3.Distance(gameObject.transform.position,Target.position) < 5.0f)
		{
			animation.CrossFade("Idle");
		}
		else if(agent.speed < 5)
		{
			animation.CrossFade("Walk");
		}
		else
		{
			animation.CrossFade("Run");
		}
		
	}
	
}
