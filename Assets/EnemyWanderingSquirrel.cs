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

    public Mesh EnemyMesh;
	
	int distanceToPlayer;
	HOMPlayer player;
    float oldSpeed = 0;
	
	public bool IsZombie;
	
	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		if(Path == null)
			shouldChasePlayer = true;
		else
			agent.SetDestination(Path.PointsInPath[0].position);
        oldSpeed = agent.speed;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<HOMPlayer>();
	}
	
	void Update()
	{
		RaycastHit hit;
		distanceToPlayer = (int)Vector3.Distance(transform.position, player.gameObject.transform.position);//Path.PointsInPath[currentDestination].position);
		if(distanceToPlayer <= DetectRange())
		{
			gameObject.transform.LookAt(player.transform);
			
			transform.LookAt(player.transform.position);
            var forward = transform.TransformDirection(Vector3.forward) * 10;
			Debug.DrawRay(transform.position, Vector3.forward * 10, Color.magenta);
            RaycastHit playerCollisionHit;
            if (Physics.Raycast(transform.position, Vector3.forward, out playerCollisionHit) && playerCollisionHit.collider.tag == "Player")
            {
                Debug.Log("I CAN SEE THE PLAYER!!!");
                agent.speed = 15;
			    agent.SetDestination(player.transform.position);
            }
            
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
            agent.speed = oldSpeed;
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
				return 3.0f;
		}
	}
	
}
