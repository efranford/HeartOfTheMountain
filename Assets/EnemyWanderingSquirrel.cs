using UnityEngine;
using System.Collections;

public class EnemyWanderingSquirrel : MonoBehaviour {
	
	NavMeshAgent agent;
	public Transform Target;
	
	public GameObject EyeLidL;
	public GameObject EyeLidR;
	public GameObject Body;
	
	public NavigationPath Path;
	
	bool shouldChasePlayer;
	int currentDestination = 0;
	
	public float DistanceToChangeTargets = 2.0f;
	
	float distanceToPlayer;
	HOMPlayer player;
	
	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		if(Path == null)
			shouldChasePlayer = true;
		else
			agent.SetDestination(Path.PointsInPath[0].position);
		
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<HOMPlayer>();
	}
	
	void Update()
	{
		RaycastHit hit;
		distanceToPlayer = Vector3.Distance(transform.position, player.gameObject.transform.position);//Path.PointsInPath[currentDestination].position);
		if(distanceToPlayer <= DetectRange())
		{
			Debug.Log(distanceToPlayer+":"+ DetectRange());
			Debug.Log("So.. I can chase the player");
			gameObject.transform.LookAt(player.transform);
			agent.SetDestination(player.transform.position);
		}
		else if(Path != null)
		{
			float distance = Vector3.Distance(transform.position,Path.PointsInPath[currentDestination].position);
			if(distance < DistanceToChangeTargets)
			{
				if(currentDestination < Path.PointsInPath.Length-1)
				{
					currentDestination++;
				}
				else
				{
					currentDestination = 0;
				}
			}
			agent.SetDestination(Path.PointsInPath[currentDestination].position);
		}
		else if(shouldChasePlayer)
		{
			agent.SetDestination(Target.position);
		}
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
	
	float DetectRange()
	{
		switch(player.State)
		{
			case PlayerState.Walking:
				return 5.0f;
			case PlayerState.Running:
				return 10.0f;
			case PlayerState.Crouching:
				return 3.0f;
			default:
				return 1.0f;
		}
	}
	
}
